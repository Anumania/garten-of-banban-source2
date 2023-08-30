using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.drone
{
	public partial class Drone : AnimatedEntity
	{
		[Net]
		public Vector3 Target { get; set; }
		public override void Spawn()
		{
			SetModel( "models/citizen_props/hotdog01/hotdog01_lod02.vmdl" );

			Scale = 5f;
			EnableDrawing = true;
			EnableHideInFirstPerson = true;
			EnableShadowInFirstPerson = true;
		}

		public void Simulate( IClient cl )
		{
	
			Rotation rot = Rotation.LookAt( Position - Target);

			Rotation = Rotation.Lerp( Rotation, rot, 0.05f );
			Rotation rotDif = Rotation.Difference( Rotation, rot );
			float goodDiff = MathF.Abs( rotDif.x ) + MathF.Abs( rotDif.y ) + MathF.Abs( rotDif.z );
			//Log.Info( goodDiff);
			if(goodDiff < 0.05f )
			{

				Position = Position.LerpTo( Target, 0.1f );
			}
			/*if (Rotation !=)
			{

			}*/
			//Position = Target;
			//Log.Info( "am i even running man" );
			base.Simulate( cl );
		}
	}
}
