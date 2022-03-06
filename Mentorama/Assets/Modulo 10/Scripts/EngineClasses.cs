using UnityEngine;
using UnityEngine.SceneManagement;

public class EngineClasses : MonoBehaviour
{
	public GameObject MeshWithPrefab;

	void Start()
	{
		// Input
		bool getKey = Input.GetKeyDown(KeyCode.Space);

		Input.GetButton("Fire1");

		Input.GetMouseButton(0);
		for (int i = 0; i < Input.touchCount; i++)
		{
			Vector2 touchPosition = Input.touches[i].position;
		}

		// Debug
		Debug.Log("Log");
		Debug.LogWarning("Warning");
		Debug.LogError("Error");
		Debug.DrawLine(Vector3.zero, Vector3.one, Color.red, 3f);
		Debug.DrawRay(Vector3.one, Vector3.forward, Color.cyan, 3f);

		// Time
		float currentTime = Time.time;
		float deltaTime = Time.deltaTime;
		Time.timeScale = 0.1f;

		// Random
		int randomInt = Random.Range(0, 42);
		float randomFloat = Random.Range(0f, 1f);
		randomFloat = Random.value;
		Vector3 randomPoint3D = Random.insideUnitSphere;
		randomPoint3D = Random.onUnitSphere; // Superfície
		Vector2 randomPoint2D = Random.insideUnitCircle;
		Quaternion randomRotation = Random.rotation;
		randomRotation = Random.rotationUniform;

		// Vector3
		Vector3 v3zero = Vector3.zero;
		Vector3 v3one = Vector3.one;
		Vector3 v3forward = Vector3.forward;
		float dotProduct = Vector3.Dot(v3zero, v3one);
		Vector3 crossProduct = Vector3.Cross(v3zero, v3one);
		Vector3 normalizedCrossProduct = Vector3.Normalize(crossProduct);
		normalizedCrossProduct = crossProduct.normalized;
		float distance = Vector3.Distance(v3zero, v3one);
		float crossProductMagnitude = Vector3.Magnitude(crossProduct);
		crossProductMagnitude = crossProduct.magnitude;
		//float angleBetween = Vector3.AngleBetween(Vector3.zero, Vector3.one); // [Deprecated] radians
		float angleBetweenVectors = Vector3.Angle(Vector3.zero, Vector3.one); // [Deprecated] radians

		// Vector2
		Vector2 v2zero = Vector2.zero;
		Vector2 v2one = Vector2.one;
		Vector2 v2right = Vector2.right;
		// ...

		// Quaternion
		Quaternion identityQuaternion = Quaternion.identity;
		Quaternion quaternion = Quaternion.Euler(1, 2, 3);
		float angleBetweenQuaternions = Quaternion.Angle(identityQuaternion, quaternion);

		// Transform
		Vector3 worldPosition = transform.position;
		Vector3 localPosition = transform.localPosition;
		Quaternion worldRotation = transform.rotation;
		Quaternion localRotation = transform.localRotation;
		Vector3 worldEulerAngle = transform.eulerAngles;
		Vector3 LocalEulerAngle = transform.localEulerAngles;

		Transform parent = transform.parent;
		int siblingIndex = transform.GetSiblingIndex();
		transform.SetSiblingIndex(1);
		bool isChildOf = transform.IsChildOf(transform);
		Transform root = transform.root;
		transform.SetAsFirstSibling();
		transform.SetAsLastSibling();
		transform.SetParent(transform);

		transform.DetachChildren();
		int childs = transform.childCount;
		transform.GetChild(1);
		for (int i = 0; i < childs; i++)
		{
			Transform child = transform.GetChild(i);
		}

		foreach (Transform child in transform)
		{

		}

		transform.Translate(0, 0, 1, Space.Self);
		transform.Rotate(30, 30, 30, Space.Self);
		transform.RotateAround(Vector3.zero, Vector3.up, 30);
		//transform.RotateAroundLocal(Vector3.up, 30); // [deprecated]
		transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
		transform.LookAt(Camera.main.transform);

		Vector3 worldPoint = transform.TransformPoint(0, 0, 1);
		Vector3 worldDirection = transform.TransformDirection(transform.forward);
		Vector3 worldVector = transform.TransformVector(0, 0, 1);

		Vector3 localPoint = transform.InverseTransformPoint(0, 0, 1);
		Vector3 localDirection = transform.InverseTransformDirection(transform.forward);
		Vector3 localVector = transform.InverseTransformVector(0, 0, 1);

		// Gizmos
		Gizmos.DrawCube(Vector3.zero, Vector3.one);

		// Camera
		Camera mainCamera = Camera.main;
		Camera currentCamera = Camera.current;
		for (int i = 0; i < Camera.allCamerasCount; i++)
		{
			var camera = Camera.allCameras[i];
		}

		// Application
		Application.Quit();
		RuntimePlatform platform = Application.platform;
		Application.runInBackground = true;
		Application.targetFrameRate = 60;
		bool isMobile = Application.isMobilePlatform;
		bool isConsole = Application.isConsolePlatform;
		bool isFocused = Application.isFocused;
		Application.focusChanged += FocusChangeHandler;
		//Application.CaptureScreenshot("myScreenshot.png"); // [deprecated]
		//Application.LoadLevel(0); // [deprecated]

		// ScreenCapture
		ScreenCapture.CaptureScreenshot("myScreenshot.png");

		// SceneManager
		SceneManager.LoadScene(0);
		//SceneManager.UnloadScene(0); // [deprecated]
		SceneManager.LoadSceneAsync(0);
		SceneManager.UnloadSceneAsync(0);
		Scene mainMenuScene = SceneManager.GetSceneByName("MainMenu");
		SceneManager.sceneLoaded += SceneLoadedHandler;
		SceneManager.sceneUnloaded += SceneUnloadedHandler;
		SceneManager.activeSceneChanged += ActiveSceneChangedHandler;

		// Cursor
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		Cursor.SetCursor(new Texture2D(32, 32), Vector2.zero, CursorMode.Auto);

		// Display
		int systemHeight = Display.main.systemHeight;
		int systemWidth = Display.main.systemWidth;
		int renderHeight = Display.main.renderingHeight;
		int renderWidth = Display.main.renderingWidth;

		// Screen
		Screen.orientation = ScreenOrientation.AutoRotation;
		int screenHeight = Screen.currentResolution.height;
		int screenWidth = Screen.currentResolution.width;
		int refreshRate = Screen.currentResolution.refreshRate;
		float dpi = Screen.dpi;
		Screen.SetResolution(screenWidth, screenHeight, FullScreenMode.ExclusiveFullScreen, 60);

		// SystemInfo
		BatteryStatus batteryStatus = SystemInfo.batteryStatus;
		float batteryLevel = SystemInfo.batteryLevel;
		DeviceType deviceType = SystemInfo.deviceType;
		string deviceUniqueIdentifier = SystemInfo.deviceUniqueIdentifier;
		string operatingSystem = SystemInfo.operatingSystem;
		string grahicsDeviceName = SystemInfo.graphicsDeviceName;
		string grahicsDeviceVendor = SystemInfo.graphicsDeviceVendor;
		int graphicsDeviceMemorySize = SystemInfo.graphicsMemorySize;
		int systemMemorySize = SystemInfo.systemMemorySize;
		bool supportsVibration = SystemInfo.supportsVibration;

		// Resources
		TextAsset textFile = Resources.Load<TextAsset>("Text/textFile01");
		TextAsset[] jsonTextFiles = Resources.LoadAll<TextAsset>("Text/");
		ResourceRequest request = Resources.LoadAsync<Texture2D>("Textures/texture01");
		Sprite sprite = Resources.Load<Sprite>("Sprites/sprite01");
		AudioClip audioClip = Resources.Load<AudioClip>("Audio/audioClip01");

		// PlayerPrefs
		PlayerPrefs.SetInt("IntKey", 0);
		int intInfo = PlayerPrefs.GetInt("IntKey", 0);
		PlayerPrefs.SetFloat("FloatKey", 0f);
		float floatInfo = PlayerPrefs.GetFloat("FloatKey", 0f);
		PlayerPrefs.SetString("StringKey", "Hello!");
		string stringInfo = PlayerPrefs.GetString("StringKey");
		bool hasKey = PlayerPrefs.HasKey("IntKey");
		PlayerPrefs.DeleteKey("IntKey");
		PlayerPrefs.DeleteAll();
	}

	private void FocusChangeHandler(bool focus)
	{
		Debug.Log($"focus: {focus}");
	}

	private void SceneLoadedHandler(Scene scene, LoadSceneMode mode)
	{

	}

	private void SceneUnloadedHandler(Scene scene)
	{

	}
	private void ActiveSceneChangedHandler(Scene from, Scene to)
	{

	}

	private void OnDrawGizmos()
	{
		Mesh capsuleMesh = MeshWithPrefab.GetComponent<MeshFilter>().sharedMesh;

		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere(Vector3.right * 3, 0.5f);
		Gizmos.color = Color.blue;
		Gizmos.DrawWireMesh(capsuleMesh, Vector3.left * 3);
		Gizmos.color = Color.magenta;
		Gizmos.DrawFrustum(Vector3.zero, 60f, 5, 1, 2f);

		Gizmos.color = Color.yellow;
		Gizmos.DrawLine(Vector3.zero, Vector3.up * 3f);
		Gizmos.color = Color.green;
		Gizmos.DrawRay(Vector3.up * 3f, Vector3.forward);
	}

	private void OnDrawGizmosSelected()
	{
		Mesh capsuleMesh = MeshWithPrefab.GetComponent<MeshFilter>().sharedMesh;

		Gizmos.color = Color.green;
		Gizmos.DrawCube(Vector3.zero, Vector3.one);
		Gizmos.color = Color.white;
		Gizmos.DrawSphere(Vector3.right * 3, 0.5f);
		Gizmos.color = Color.gray;
		Gizmos.DrawMesh(capsuleMesh, Vector3.left * 3);
	}
}