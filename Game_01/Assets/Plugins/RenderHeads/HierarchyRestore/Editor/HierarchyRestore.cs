﻿#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

//-----------------------------------------------------------------------------
// Copyright 2017 RenderHeads Ltd.  All rights reserverd.
//-----------------------------------------------------------------------------

namespace RenderHeads.Framework.Editor
{
	/// <summary>
	/// Create a hidden node in the scene which tracks the selection state and hierarchy expansion state
	/// When this node is deleted (by changing scene) it will save the last state it has.
	/// When the node is created it will try to restore the selection and hierarchy expansion state if it
	/// has this saved to EditorPrefs for the specific project and scene.
	/// </summary>
	[InitializeOnLoad]
	public class HierarchyRestore
	{
		private const string GameObjectName = "Temp-SceneCreatedMarker";
		private static GameObject _cachedGo = null;

		// This is called when Unity first loads and also each time any scripts are compiled
		static HierarchyRestore()
		{
			// The hierarchyWindowChanged fires when nodes are added, moved or removed from the hierarchy
			// Loading a new scene also changes the hierarchy
			EditorApplication.hierarchyWindowChanged -= OnHierarchyWindowChanged;
			EditorApplication.hierarchyWindowChanged += OnHierarchyWindowChanged;
		}

		private static void OnHierarchyWindowChanged()
		{
			if (IsSceneChanged())
			{
				// Create our marker
				_cachedGo = new GameObject(GameObjectName, typeof(HierarchyNode));

				// Note: We don't use the DontSaveInEditor flag as this causes OnDestroy/OnDisable() to not be called when the scene unloads
				_cachedGo.hideFlags = HideFlags.NotEditable | HideFlags.HideInHierarchy | HideFlags.HideInInspector;
#if UNITY_5 || UNITY_5_4_OR_NEWER
				_cachedGo.hideFlags |= HideFlags.DontSaveInBuild;
#endif
			}
		}

		private static bool IsSceneChanged()
		{
			bool result = false;
			if (_cachedGo == null && !EditorApplication.isPlaying && !EditorApplication.isPlayingOrWillChangePlaymode && !EditorApplication.isUpdating)
			{
				_cachedGo = GameObject.Find(GameObjectName);
				// It's a new scene because our marker node doesn't exist
				if (_cachedGo == null)
				{
					result = true;
				}
			}
			return result;
		}
	}
}
#endif