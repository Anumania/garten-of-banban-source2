using Sandbox;

namespace MyGame;

public partial class Pistol : Weapon
{
	public override string ModelPath => "weapons/rust_pistol/rust_pistol.vmdl";
	public override string ViewModelPath => "weapons/rust_pistol/v_rust_pistol.vmdl";

	[ClientRpc]
	protected virtual void ShootEffects()
	{
		Game.AssertClient();

		Particles.Create( "particles/pistol_muzzleflash.vpcf", EffectEntity, "muzzle" );

		Pawn.SetAnimParameter( "b_attack", true );
		ViewModelEntity?.SetAnimParameter( "fire", true );
	}

	public override void PrimaryAttack()
	{
		//ShootEffects();
		//Pawn.PlaySound( "rust_pistol.shoot" );
		//ShootBullet( 0.1f, 100, 20, 1 );
		Ray droneRay = new Ray( Owner.AimRay.Position, Camera.Rotation.Forward );
		TraceResult tr = Trace.Ray( droneRay, 400f ).WorldAndEntities().Run();
		//Log.Info( "am i server or client" );
		Pawn.MyDrone.Target = tr.EndPosition;
	}

	public override void SecondaryAttack()
	{
		Pawn.MyDrone.Position = Owner.AimRay.Position + Vector3.Up*50f;
		Pawn.MyDrone.Rotation = Owner.Rotation;
		Pawn.MyDrone.Target = Pawn.MyDrone.Position;
	}

	protected override void Animate()
	{
		Pawn.SetAnimParameter( "holdtype", (int)CitizenAnimationHelper.HoldTypes.Pistol );
	}
}
