using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
	internal class TestEffect : RenderHook
	{
		public override void OnStage( SceneCamera target, Stage renderStage )
		{
			/*if ( renderStage ==  )
			{
				RenderAttributes ra = new();
				//Graphics.GrabDepthTexture( "DepthTexture", ra );
				//Graphics.RenderTarget = null;
				//Graphics.Clear();
			}*/
			base.OnStage( target, renderStage );
		}
	}
}
