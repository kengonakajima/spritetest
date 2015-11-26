using UnityEngine;
using System.Collections;

public class GLtest : MonoBehaviour {

    private Material m_material;

    void Start () {
        // マテリアルの生成.
        /*        
        m_material = new Material(
                                  "Shader \"myShader\" {" +
                                  "  SubShader {" +
                                  "    Pass {" +
                                  "       ZWrite Off" +
                                  "       Cull Off" + 
                                  "       BindChannels {" +
                                  "         Bind \"vertex\", vertex Bind \"color\", color" +
                                  "       }" +
                                  "    }" +
                                  "  }" +
                                  "}"
                                  );*/
        m_material = new Material( Shader.Find( "Particles/Alpha Blended" ) );
        m_material.hideFlags = HideFlags.HideAndDontSave;
        m_material.shader.hideFlags = HideFlags.HideAndDontSave;
    }

    void OnPostRender() {
        if (m_material != null) {
            m_material.SetPass(0);  // マテリアルのパス0を割り当て.
  
            GL.PushMatrix();
            GL.LoadOrtho();   // 2D描画として処理.
            GL.Begin(GL.TRIANGLES);

            GL.Color(Color.red);
            GL.Vertex3( 0.0f, 0.0f, 0.0f );

            GL.Color(Color.green);
            GL.Vertex3(0.0f, 1.0f, 0.0f );

            GL.Color(Color.blue);
            GL.Vertex3(0.5f, 0.5f, 0.0f );

            GL.End();
            GL.PopMatrix();
        }
    }    
	
	// Update is called once per frame
	void Update () {
	
	}
}


