var placed : Transform;
var water : Texture;

function Update () {
var cam : Transform = Camera.main.transform;
var ray = new Ray(cam.position, cam.forward);
var hit : RaycastHit;
if(Physics.Raycast (ray, hit, 5)){
if ( Input.GetMouseButtonDown(0)){
Destroy(hit.transform.gameObject);
}
if ( Input.GetMouseButtonDown(1)){
Instantiate (placed , hit.point , Quaternion.identity);
}
}
}
