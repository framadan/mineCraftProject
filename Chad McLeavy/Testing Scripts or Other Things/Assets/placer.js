private var cube : Transform;
var sand : Transform;
var grass : Transform;
var heightMap : Texture2D;
var size = Vector3 (300, 10, 100);
var redMat : Material;
var blackMat : Material;

function Start () {
	var x : int = transform.position.x * heightMap.width / size.x;
	var z : int = transform.position.z * heightMap.height / size.z;
	transform.position.y = Mathf.RoundToInt(heightMap.GetPixel(x, z).grayscale * 15);
	var cube = grass;
	
	if (transform.position.y > 6){
	GetComponent.<Renderer>().material = redMat;
	} else {
	GetComponent.<Renderer>().material = blackMat;
	cube = sand;
	}
	
	for (var i : int = 0;i < 5; i++) {
        Instantiate (cube, transform.position + Vector3(0, -1 + (-i), 0), Quaternion.identity);
    }
}