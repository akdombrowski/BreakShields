using System;

using HarmonyLib;

using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace BreakShield
{
    [HarmonyPatch]
    public class SubModule : MBSubModuleBase
    {
        private static Type[] argumentTypes = new Type[]
        {typeof(AttackInformation).MakeByRefType(),
      typeof(bool),
      typeof(float),
      typeof(AttackCollisionData).MakeByRefType(),
      typeof(MissionWeapon).MakeByRefType(),
      typeof(bool),
      typeof(CombatLogData).MakeByRefType(),
      typeof(int).MakeByRefType()
        };

        //public static void breakShieldOld(ref AttackInformation attackInformation, ref AttackCollisionData attackCollisionData, MissionWeapon victimShield)
        //{
        //  Harmony.DEBUG = false;

        //  // Harmony.DEBUG = true;

        //  bool isShield = victimShield.IsShield();
        //  Debug.Print("prefix isShield: " + isShield);
        //  FileLog.Log("prefix isShield: " + isShield);
        //  Debug.Print("");
        //  FileLog.Log("");

        //  if (isShield)
        //  {
        //    int shieldHealth = victimShield.ModifiedMaxHitPoints;

        //    Debug.Print("prefix shieldHealth: " + shieldHealth);
        //    FileLog.Log("prefix shieldHealth: " + shieldHealth);

        //    Debug.Print("prefix before isShieldBroken: " + attackCollisionData.IsShieldBroken);
        //    Debug.Print("prefix before InflictedDamage: " + attackCollisionData.InflictedDamage);
        //    FileLog.Log("prefix before isShieldBroken: " + attackCollisionData.IsShieldBroken);
        //    FileLog.Log("prefix before InflictedDamage: " + attackCollisionData.InflictedDamage);

        //    AttackCollisionData acd = AttackCollisionData.GetAttackCollisionDataForDebugPurpose(
        //      attackCollisionData.AttackBlockedWithShield,
        //      attackCollisionData.CorrectSideShieldBlock,
        //      attackCollisionData.IsAlternativeAttack,
        //      attackCollisionData.IsColliderAgent,
        //      attackCollisionData.CollidedWithShieldOnBack,
        //      attackCollisionData.IsMissile,
        //      attackCollisionData.MissileBlockedWithWeapon,
        //      attackCollisionData.MissileHasPhysics,
        //      attackCollisionData.EntityExists,
        //      attackCollisionData.ThrustTipHit,
        //      attackCollisionData.MissileGoneUnderWater,
        //      attackCollisionData.CollisionResult,
        //      attackCollisionData.AffectorWeaponSlotOrMissileIndex,
        //      attackCollisionData.StrikeType,
        //      attackCollisionData.DamageType,
        //      attackCollisionData.CollisionBoneIndex,
        //      attackCollisionData.VictimHitBodyPart,
        //      attackCollisionData.AttackBoneIndex,
        //      attackCollisionData.AttackDirection,
        //      attackCollisionData.PhysicsMaterialIndex,
        //      attackCollisionData.CollisionHitResultFlags,
        //      attackCollisionData.AttackProgress,
        //      attackCollisionData.CollisionDistanceOnWeapon,
        //      attackCollisionData.AttackerStunPeriod,
        //      attackCollisionData.DefenderStunPeriod,
        //      attackCollisionData.MissileTotalDamage,
        //      attackCollisionData.MissileStartingBaseSpeed,
        //      attackCollisionData.ChargeVelocity,
        //      attackCollisionData.FallSpeed,
        //      attackCollisionData.WeaponRotUp,
        //      attackCollisionData.WeaponBlowDir,
        //      attackCollisionData.CollisionGlobalPosition,
        //      attackCollisionData.MissileVelocity,
        //      attackCollisionData.MissileStartingPosition,
        //      attackCollisionData.VictimAgentCurVelocity,
        //      attackCollisionData.CollisionGlobalNormal);

        //    AttackInformation ai = new AttackInformation(attackInformation.ArmorAmountFloat, attackInformation.ShieldOnBack, attackInformation.VictimAgentFlag, attackInformation.VictimAgentAbsorbedDamageRatio, attackInformation.DamageMultiplierOfBone, attackInformation.CombatDifficultyMultiplier, attackInformation.VictimMainHandWeapon, attackInformation.VictimShield, true, attackInformation.IsVictimAgentLeftStance, attackInformation.IsFriendlyFire, attackInformation.DoesAttackerHaveMountAgent, attackInformation.DoesVictimHaveMountAgent, attackInformation.AttackerAgentMovementVelocity, attackInformation.AttackerAgentMountMovementDirection, attackInformation.AttackerMovementDirectionAsAngle, attackInformation.VictimAgentMovementVelocity, attackInformation.VictimAgentMountMovementDirection, attackInformation.VictimMovementDirectionAsAngle, attackInformation.IsVictimAgentSameWithAttackerAgent, attackInformation.IsAttackerAgentMine, attackInformation.DoesAttackerHaveRiderAgent, attackInformation.IsAttackerAgentRiderAgentMine, attackInformation.IsAttackerAgentMount, attackInformation.IsVictimAgentMine, attackInformation.DoesVictimHaveRiderAgent, attackInformation.IsVictimAgentRiderAgentMine, attackInformation.IsVictimAgentMount, attackInformation.IsAttackerAgentNull, attackInformation.IsAttackerAIControlled, attackInformation.AttackerAgentCharacter, attackInformation.AttackerAgentOrigin, attackInformation.VictimAgentCharacter, attackInformation.VictimAgentOrigin, attackInformation.AttackerAgentMovementDirection, attackInformation.AttackerAgentVelocity, attackInformation.AttackerAgentMountChargeDamageProperty, attackInformation.AttackerAgentCurrentWeaponOffset,
        //  attackInformation.IsAttackerAgentHuman,
        //  attackInformation.IsAttackerAgentActive,
        //  attackInformation.IsAttackerAgentDoingPassiveAttack,
        //  attackInformation.IsVictimAgentNull,
        //  attackInformation.VictimAgentScale,
        //  attackInformation.VictimAgentHealth,
        //  attackInformation.VictimAgentMaxHealth,
        //  attackInformation.VictimAgentWeight,
        //  attackInformation.VictimAgentTotalEncumbrance,
        //  attackInformation.IsVictimAgentHuman,
        //  attackInformation.VictimAgentVelocity,
        //  attackInformation.VictimAgentPosition,
        //  attackInformation.WeaponAttachBoneIndex,
        //  attackInformation.OffHandItem,
        //  attackInformation.IsHeadShot,
        //  attackInformation.IsVictimRiderAgentSameAsAttackerAgent,
        //  attackInformation.IsAttackerPlayer,
        //  attackInformation.IsVictimPlayer);

        //    acd.IsShieldBroken = true;
        //    acd.InflictedDamage = shieldHealth * 2;
        //    attackCollisionData = acd;

        //    MissionWeapon sh = ai.VictimShield;
        //    sh.HitPoints = 0;
        //    ai.VictimShield = sh;
        //    attackInformation = ai;

        //    Debug.Print("prefix isShieldBroken: " + attackCollisionData.IsShieldBroken);
        //    Debug.Print("prefix InflictedDamage: " + attackCollisionData.InflictedDamage);
        //    FileLog.Log("prefix isShieldBroken: " + attackCollisionData.IsShieldBroken);
        //    FileLog.Log("prefix InflictedDamage: " + attackCollisionData.InflictedDamage);
        //    FileLog.Log("prefix attackInformation.VictimShield.HitPoints: " + attackInformation.VictimShield.HitPoints);

        //    Debug.Print("");
        //    FileLog.Log("");
        //    Debug.Print("");
        //    FileLog.Log("");
        //  }

        //  Harmony.DEBUG = false;
        //}

        // Mission.GetAttackCollisionResults()
        //[HarmonyPostfix]
        //[HarmonyPatch(typeof(Mission), "GetAttackCollisionResults")]
        //public static void GetAttackCollisionResults() {
        
        //}
  
    // Mission.ComputeBlowDamageOnShield()
        [HarmonyPostfix]
        [HarmonyPatch(typeof(Mission), "ComputeBlowDamageOnShield")]
        public static void MyPostfix(bool isAttackerAgentNull,
      bool isAttackerAgentActive,
      bool isAttackerAgentDoingPassiveAttack,
      bool canGiveDamageToAgentShield,
      bool isVictimAgentLeftStance,
      MissionWeapon victimShield,
      ref AttackCollisionData attackCollisionData,
      WeaponComponentData attackerWeapon,
      float blowMagnitude)
        {
            Harmony.DEBUG = false;

            // Harmony.DEBUG = true;

            //Debug.Print("");
            //FileLog.Log("");
            //Debug.Print("isAttackerAgentNull: " + isAttackerAgentNull);
            //FileLog.Log("isAttackerAgentNull: " + isAttackerAgentNull);
            //Debug.Print("isAttackerAgentActive: " + isAttackerAgentActive);
            //FileLog.Log("isAttackerAgentActive: " + isAttackerAgentActive);



            if (!isAttackerAgentNull && isAttackerAgentActive)
            {
                //Debug.Print("before attackCollisionData.InflictedDamage: " + attackCollisionData.InflictedDamage);
                //FileLog.Log("before attackCollisionData.InflictedDamage: " + attackCollisionData.InflictedDamage);
                //Debug.Print("before attackCollisionData.AttackerStunPeriod: " + attackCollisionData.AttackerStunPeriod);
                //FileLog.Log("before attackCollisionData.AttackerStunPeriod: " + attackCollisionData.AttackerStunPeriod);
                //Debug.Print("before attackCollisionData.IsShieldBroken:  " + attackCollisionData.IsShieldBroken);
                //FileLog.Log("before attackCollisionData.IsShieldBroken:  " + attackCollisionData.IsShieldBroken);
                //Debug.Print("before victimShield.HitPoints: " + victimShield.HitPoints);
                //FileLog.Log("before victimShield.HitPoints: " + victimShield.HitPoints);

                //Debug.Print("");
                //FileLog.Log("");

                attackCollisionData.InflictedDamage = victimShield.HitPoints * 10;
                attackCollisionData.AttackerStunPeriod = 0;
                attackCollisionData.IsShieldBroken = true;
                victimShield.HitPoints = 0;

                //Debug.Print("after attackCollisionData.InflictedDamage: " + attackCollisionData.InflictedDamage);
                //FileLog.Log("after attackCollisionData.InflictedDamage: " + attackCollisionData.InflictedDamage);
                //Debug.Print("after attackCollisionData.AttackerStunPeriod: " + attackCollisionData.AttackerStunPeriod);
                //FileLog.Log("after attackCollisionData.AttackerStunPeriod: " + attackCollisionData.AttackerStunPeriod);
                //Debug.Print("after attackCollisionData.IsShieldBroken:  " + attackCollisionData.IsShieldBroken);
                //FileLog.Log("after attackCollisionData.IsShieldBroken:  " + attackCollisionData.IsShieldBroken);
                //Debug.Print("after victimShield.HitPoints: " + victimShield.HitPoints);
                //FileLog.Log("after victimShield.HitPoints: " + victimShield.HitPoints);

                //Debug.Print("");
                //FileLog.Log("");
                //Debug.Print("");
                //FileLog.Log("");
            }

            Harmony.DEBUG = false;
        }

        //[HarmonyPostfix]
        //public static void MyPostfixOld(ref AttackInformation attackInformation,
        //  bool crushedThrough,
        //  float momentumRemaining,
        //  ref AttackCollisionData attackCollisionData,
        //  in MissionWeapon attackerWeapon,
        //  bool cancelDamage)
        //{
        //  if (attackInformation.IsAttackerPlayer && attackInformation.IsVictimAgentHuman && attackCollisionData.AttackBlockedWithShield)
        //  {
        //    Debug.Print("postfix attackCollisionData.IsShieldBroken: " + attackCollisionData.IsShieldBroken);
        //    Debug.Print("postfix attackCollisionData.InflictedDamage: " + attackCollisionData.InflictedDamage);
        //    FileLog.Log("postfix attackCollisionData.IsShieldBroken: " + attackCollisionData.IsShieldBroken);
        //    FileLog.Log("postfix attackCollisionData.InflictedDamage: " + attackCollisionData.InflictedDamage);
        //    FileLog.Log("postfix crushedThrough: " + crushedThrough);
        //    FileLog.Log("postfix attackInformation.VictimShield.HitPoints: " + attackInformation.VictimShield.HitPoints);
        //    Debug.Print("");
        //    FileLog.Log("");
        //    Debug.Print("");
        //    FileLog.Log("");
        //  }
        //}


        //public static bool MyPrefixOld(ref AttackInformation attackInformation,
        //  bool crushedThrough,
        //  float momentumRemaining,
        //  ref AttackCollisionData attackCollisionData,
        //  in MissionWeapon attackerWeapon,
        //  bool cancelDamage
        //  )
        //{
        //  if (attackInformation.IsAttackerPlayer && attackInformation.IsVictimAgentHuman && attackCollisionData.AttackBlockedWithShield)
        //  {
        //    breakShieldOld(ref attackInformation, ref attackCollisionData, attackInformation.VictimShield);
        //  }

        //  // run the original method after the prefix method
        //  return true;
        //}

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();
            var harmony = new Harmony("com.BreakShield.akdombrowski");

            //var mOriginal = AccessTools.Method(typeof(Mission), "ComputeBlowDamageOnShield");
            ////var mPrefix = typeof(SubModule).GetMethod("MyPrefix");
            //var mPostfix = typeof(SubModule).GetMethod("MyPostfix");
            //// var mPostfix = SymbolExtensions.GetMethodInfo(() => MyPostfix());
            //harmony.Patch(mOriginal, new HarmonyMethod(mPostfix));

            harmony.PatchAll();

            InformationManager.DisplayMessage(new InformationMessage("Loaded 'BreakShield'.", Color.FromUint(4282500842U)));
        }
    }
}