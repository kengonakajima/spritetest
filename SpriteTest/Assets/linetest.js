#pragma strict
function DrawGLLine(P1:Vector3,P2:Vector3)
{

    GL.PushMatrix();
    GL.LoadOrtho();
    GL.Begin(GL.LINES);
    GL.Color(Color.red);
    GL.Vertex(P1);
    GL.Vertex(P2);
    GL.End();
    GL.PopMatrix();        
}

function Start () {

}

function Update () {
    DrawGLLine( Vector3(0,0,0), Vector3(100,100,10) );

}