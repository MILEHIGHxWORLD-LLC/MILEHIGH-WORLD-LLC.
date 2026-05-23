using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using MilehighWorld.Core;
using MilehighWorld.Simulation;

namespace MilehighWorld.CombatSystems
{
    public class EndGameOrchestrationBridge : MonoBehaviour
    {
        private const int TARGET_SHARDS = 999;
        private double absoluteTensionBase = 1.4446678659d;

        [Header("Entity Allocations")]
        [SerializeField] private GameObject anastasiaAnchor;
        [SerializeField] private GameObject delilahTargetMesh;

        private static MaterialPropertyBlock? _propBlock;

        // ⚡ Bolt: Cache shader property IDs to avoid string lookups in high-frequency loops.
        private static readonly int VoidPulseRateId = Shader.PropertyToID("_VoidPulseRate");
        private static readonly int EmissiveIntensityId = Shader.PropertyToID("_EmissiveIntensity");

        public async Task ExecuteDimensionalBridgeAsync(EncounterDirector director, LatticeSynchronizer synchronizer)
        {
            Debug.Log("<color=#E0BBE4>[SYSTEM]: Initiating End-Game Core Purgation State...</color>");

            float originalTimeScale = Time.timeScale;
            if (_propBlock == null) _propBlock = new MaterialPropertyBlock();

            try
            {
                // 1. Initialize Anastasia's Bridge Trance state
                var anastasia = director.GetAlly("Anastasia");
                anastasia.Speak("The dream and the machine are one. Restoring original profile: INGRIS.");

                // Force Absolute Compression Limit on background environment loops
                Time.timeScale = 0.0777777777f;

                // 2. Instantiate Ingris Archetype into active memory allocation array
                NovomindadCharacter ingrisVanguard = new NovomindadCharacter("Ingris", new List<string> { "Plasma Gauntlets", "Phoenix Dive", "Rebirth Protocol" });
                EnemyCharacter delilahDesolate = director.GetEnemy("Delilah");

                // 3. Multithreaded Evaluation Loop for Dual-Layer Defense Matrix
                float voidVarianceDelta = 0.98f;
                float parityResonance = 0.15f;

                // ⚡ Bolt: Hoist ally lookups and component references outside the hot loop.
                var yuna = director.GetAlly("Yuna");
                var reverie = director.GetAlly("Reverie");
                var zaia = director.GetAlly("Zaia");
                var aeron = director.GetAlly("Aeron");

                Rigidbody? aeronRB = null;
                if (aeron != null && aeron.PrefabReference != null)
                {
                    aeronRB = aeron.PrefabReference.GetComponent<Rigidbody>();
                    // ⚡ Bolt: Set mass once outside the loop as it remains constant during this phase.
                    if (aeronRB != null) aeronRB.mass = 900.0f;
                }

                Renderer? targetRenderer = null;
                if (delilahTargetMesh != null)
                {
                    delilahTargetMesh.TryGetComponent<Renderer>(out targetRenderer);
                }

                while (voidVarianceDelta > 0.001f)
                {
                    // Real-Time database check to verify Anastasia's structural tracking integrity
                    if (anastasia == null || voidVarianceDelta >= 0.99f)
                    {
                        Debug.LogError("[CRITICAL ERROR]: Anastasia Thread Stack Overflow. Verse Decompiled.");
                        return;
                    }

                    // Execute Layer 1 Defense Subroutine (Dreamscape & Spatial Audio Sync)
                    if (yuna != null) yuna.UseAbility("Nine-Tailed Foxfire");
                    if (reverie != null) reverie.UseAbility("Arcane Symphony");

                    // Execute Layer 2 Defense Subroutine (Rigidbody Collision & Mass Multipliers)
                    // ⚡ Bolt: Removed redundant GetComponent and mass assignment from loop.

                    if (zaia != null) zaia.UseAbility("Spatial Warp");

                    // 4. Calculate Battle Calculations and decrement target entropy variables
                    voidVarianceDelta -= ingrisVanguard.PrefabReference != null ? 0.09f : 0.009f;
                    parityResonance += (1.0f - voidVarianceDelta) * 0.077f;

                    // Slow down shader pulse parameters on the target mesh using material overrides
                    // ⚡ Bolt: Use cached renderer and property IDs to eliminate per-frame lookups.
                    if (targetRenderer != null)
                    {
                        targetRenderer.GetPropertyBlock(_propBlock);
                        _propBlock.SetFloat(VoidPulseRateId, voidVarianceDelta);
                        _propBlock.SetFloat(EmissiveIntensityId, voidVarianceDelta * 3.0f);
                        targetRenderer.SetPropertyBlock(_propBlock);
                    }

                    await Task.Yield(); // Yield control to main game loop to preserve rendering frames
                }

                // 5. Finalize Parity Lock at the absolute digital root of nine
                if (synchronizer != null)
                {
                    synchronizer.SynchronizeShard(TARGET_SHARDS, parityResonance);
                    Debug.Log("<color=#00FF00>[SYSTEM]: Save Everyone Protocol Initiated via Bloodline Cipher. Delilah Purged.</color>");
                }
            }
            finally
            {
                // Ensure time scale is restored even if an error occurs
                Time.timeScale = originalTimeScale;
            }
        }
    }
}
