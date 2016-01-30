#pragma strict

var energyPerSecond = 5.0; 

function Start () {

}

function Update () {
    var slider : UnityEngine.UI.Slider = gameObject.GetComponent("Slider");
    slider.value += energyPerSecond * Time.deltaTime;
}