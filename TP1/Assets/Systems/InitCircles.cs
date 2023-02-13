using UnityEngine;
public class InitCircles : ISystem
{
    public bool initialized = false;

    public void UpdateSystem(){
        Vector2 x = new Vector2(300,300); 
        if (!initialized){
            ECSManager.Instance.CreateShape(2,3);
            ECSManager.Instance.UpdateShapePosition(2,x);
            initialized=true;
            Debug.Log("INIT DONE");
        } else{
            Color c = new Color(0,1,0,0);
            x += (new Vector2(1,1))*0.05f;
            ECSManager.Instance.UpdateShapeColor(2,c);
            ECSManager.Instance.UpdateShapePosition(2,x);
            Debug.Log("LOOPING");
        }
    }
    public string Name { get; } = "Initialization System";
}