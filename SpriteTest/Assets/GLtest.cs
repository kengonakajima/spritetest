﻿using UnityEngine;
using System.Collections;


public class GLtest : MonoBehaviour {

    private Material m_material;
    private Material m_mat2;
    private Material m_mat3;    
    private Texture2D m_tex_base;
    private Texture2D m_tex_wood;
    
    void Start () {
        m_material = new Material( Shader.Find( "Particles/Alpha Blended" ) );
        m_material.hideFlags = HideFlags.HideAndDontSave;
        m_material.shader.hideFlags = HideFlags.HideAndDontSave;

        //        m_tex_base = Resources.Load<Texture2D>("base") as Texture2D;
        m_tex_base = Resources.Load<Texture2D>("base") as Texture2D;        
        m_tex_wood = Resources.Load<Texture2D>("wood256") as Texture2D;        

        m_mat2 = new Material( Shader.Find( "Particles/Alpha Blended" ) );
        m_mat2.hideFlags = HideFlags.HideAndDontSave;
        m_mat2.shader.hideFlags = HideFlags.HideAndDontSave;
        m_mat2.SetTexture( "_MainTex", m_tex_base);

        m_mat3 = new Material( Shader.Find( "Particles/Alpha Blended" ) );
        m_mat3.hideFlags = HideFlags.HideAndDontSave;
        m_mat3.shader.hideFlags = HideFlags.HideAndDontSave;
        m_mat3.SetTexture( "_MainTex", m_tex_wood);

        Camera cam = GetComponent<Camera>();
        Debug.Log(cam);
        Debug.Log(cam.rect);
        //        cam.rect.width = 2;
        //        cam.rect.height = 2;
        //        cam.rect = new Rect(0,0,2,2);//Screen.width,Screen.height);
    }

    void OnPostRender() {
        if (m_material != null) {
            //            m_material.SetPass(0);  // マテリアルのパス0を割り当て.

  
            GL.PushMatrix();
            // GL.LoadOrtho();   // 2D描画として処理.
            GL.LoadPixelMatrix();
            //            GL.Viewport( new Rect(0,0,Screen.width/2,Screen.height) );

            m_mat3.SetPass(0);

            /*
            GL.Color(Color.red);
            GL.Begin(GL.TRIANGLES);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, Screen.height / 2, 0);
            GL.Vertex3(Screen.width / 2, Screen.height / 2, 0);
            GL.End();
            */

            int w = Screen.width;
            int h = Screen.height;
            
            GL.Begin(GL.QUADS);
            
            GL.TexCoord2(0f,0f);
            GL.Color(Color.red);
            GL.Vertex3( 0f, 0f, 0.0f );

            GL.TexCoord2(0f,1f);            
            GL.Color(Color.green);
            GL.Vertex3(0, h, 0.0f );

            GL.TexCoord2(1f,1f);                        
            GL.Color(Color.blue);
            GL.Vertex3(w, h, 0.0f );

            GL.TexCoord2(1f, 0f);
            GL.Color(Color.yellow);            
            GL.Vertex3(w, 0, 0.0f );

            GL.End();

            m_mat2.SetPass(0);
            GL.Begin(GL.QUADS);
            GL.TexCoord2(0f,1f-1f/32f);
            GL.Vertex3( 0f, 0f, 0.0f );
            GL.TexCoord2(0f,1f);            
            GL.Vertex3(0f, 24, 0.0f );
            GL.TexCoord2(1f/32f,1f);                        
            GL.Vertex3(24, 24, 0.0f );
            GL.TexCoord2(1f/32f, 1f-1f/32f);
            GL.Vertex3(24, 0f, 0.0f );
            GL.End();            
            
            GL.PopMatrix();
        }
    }    
	
	// Update is called once per frame
	void Update () {
	
	}
}


