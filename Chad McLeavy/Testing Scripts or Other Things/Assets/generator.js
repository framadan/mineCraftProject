var cube : Transform;
private var i : int;
private var z : int = 0;
var width : int;
var lenght : int;

function Start () {
Line();
}

function Line () {
for (i = 0; i < width; i++){
        Instantiate (cube , transform.position + Vector3 ( 1 + i, 0, 0), Quaternion.identity);
        }
        z++;
}

function Update () {
	if (i == width && z < lenght){
		transform.position = transform.position + Vector3 ( 0, 0, 1);
		i = 0;
		Line();
	}
}