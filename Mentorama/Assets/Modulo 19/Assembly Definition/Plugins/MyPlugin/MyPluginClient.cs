using ClassLibrary;
using UnityEngine;

public class MyPluginClient : MonoBehaviour
{
	void Start()
	{
		var classObject = new ClassLibrary.Class1();
		classObject.StringVariable = "Hello World";

		var staticIntVariable = Class1.IntVariable;
	}
}
