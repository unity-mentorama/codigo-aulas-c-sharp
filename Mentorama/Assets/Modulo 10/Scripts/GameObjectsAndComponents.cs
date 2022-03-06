using UnityEngine;

public class GameObjectsAndComponents : MonoBehaviour
{
	public GameObject GameObjectPrefab;
	public HealthComponent HealthComponentPrefab;

	private void Start()
	{
		// Encontrando GameObjetcs (Somente ativos).
		GameObject scriptsObject = GameObject.Find("Scripts");
		GameObject cubeObject = GameObject.FindWithTag("Cube");
		GameObject[] sphereObjects = GameObject.FindGameObjectsWithTag("Sphere");

		bool hasCubeTag = this.gameObject.CompareTag("Cube");
		hasCubeTag = cubeObject.CompareTag("Cube");

		// Ativando e Desativando GameObjects.
		this.gameObject.SetActive(false);
		//gameObject.SetActiveRecursively(false); // [deprecated]
		//gameObject.active = false; // [deprecated]
		bool isActive = this.gameObject.activeInHierarchy;

		// Encontrando Components dos GameObjects.
		HealthComponent cubeHealthComponent = (HealthComponent)cubeObject.GetComponent("HealthComponent");
		cubeHealthComponent.CurrentHealth = 10;

		var myHealthComponent = this.gameObject.GetComponent<HealthComponent>();
		//myHealthComponent.CurrentHealth = 10; // Null ref.

		if (this.gameObject.TryGetComponent<HealthComponent>(out var healthComponent2))
		{
			healthComponent2.MaxHealth = 12;
		}

		// Setup.
		var allSpheresObject = GameObject.Find("AllSpheres");
		var lastActiveSphere = sphereObjects[sphereObjects.Length - 1];

		// Components em filhos e parentes.
		HealthComponent componentInChildren = allSpheresObject.GetComponentInChildren<HealthComponent>(false); // Default false.
		HealthComponent componentInParent = lastActiveSphere.GetComponentInParent<HealthComponent>(false);

		// Multiplos componentes de uma vez.
		HealthComponent[] healthComponents = this.gameObject.GetComponents<HealthComponent>();
		HealthComponent[] componentsInChildren = allSpheresObject.GetComponentsInChildren<HealthComponent>();
		HealthComponent[] componentsInParent = this.gameObject.GetComponentsInParent<HealthComponent>();

		//Object[] objectsOfType = Object.FindSceneObjectsOfType(typeof(EnemyIA)); // [deprecated]

		// Ativando e desativando Componentes.
		cubeHealthComponent.enabled = false;
		bool isActiveAndEnabled = cubeHealthComponent.isActiveAndEnabled;

		// Fields da base class Object.
		string objectName = cubeHealthComponent.name;
		string componentName = cubeObject.name;

		// Fields comuns entre GameObjects e Components.
		string objectTag = cubeHealthComponent.tag;
		string componentTag = cubeObject.tag;
		Transform objectTransform = cubeObject.transform;
		Transform componentTransform = cubeHealthComponent.transform;

		// Criando novos GameObjects.
		GameObject prefabClone = Object.Instantiate(GameObjectPrefab, Vector3.one, Quaternion.identity, this.transform);
		HealthComponent prefabCloneComponent = Object.Instantiate(HealthComponentPrefab);
		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		GameObject sphereClone = Object.Instantiate(sphere);
		GameObject myClone = Object.Instantiate(this.gameObject); // Cuidado!

		// Adicionando componentes via código.
		HealthComponent healthComponent = new HealthComponent(10, 10); // Não funciona
		healthComponent = (HealthComponent)gameObject.AddComponent(typeof(HealthComponent));
		HealthComponent newHealthComponent = this.gameObject.AddComponent<HealthComponent>();
		newHealthComponent.MaxHealth = 10;
		newHealthComponent.CurrentHealth = 10;
		newHealthComponent.Initialize(5, 10);

		// Destruindo GameObjects e Components.
		Object.Destroy(allSpheresObject);
		MonoBehaviour.Destroy(cubeHealthComponent, 5f);
		GameObject.DestroyImmediate(sphere);

		DontDestroyOnLoad(this.gameObject);
	}
}
