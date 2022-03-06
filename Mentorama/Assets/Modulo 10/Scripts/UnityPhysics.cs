using UnityEngine;

public class UnityPhysics : MonoBehaviour
{
	private void Start()
	{
		// Colliders.
		Collider collider = new Collider(); // Não pode instanciar assim.
		collider = GetComponent<Collider>(); // Mas pode pegar a versão genérica com GetComponent.

		string colliderName = collider.name;
		string colliderTag = collider.tag;
		Transform colliderTransform = collider.transform;
		// enabled, gameOject, etc.

		bool isTrigger = collider.isTrigger;
		PhysicMaterial colliderPhisicsMaterial = collider.material;

		// Implementações de colliders.
		BoxCollider boxCollider = new BoxCollider();
		SphereCollider sphereCollider = new SphereCollider();
		CapsuleCollider capsuleCollider = new CapsuleCollider();
		WheelCollider wheelCollider = new WheelCollider();
		TerrainCollider terrainCollider = new TerrainCollider();
		MeshCollider meshCollider = new MeshCollider();

		// Ray.
		Ray ray = new Ray(Vector3.zero, Vector3.right);

		// Raycast.
		bool raycastHit = Physics.Raycast(ray);
		raycastHit = Physics.Raycast(Vector3.zero, Vector3.right);

		raycastHit = Physics.Raycast(ray, 5f);
		raycastHit = Physics.Raycast(ray, out var hitInfo);
		raycastHit = Physics.Raycast(ray, out hitInfo, 5f, LayerMask.NameToLayer("Terrain"), QueryTriggerInteraction.Ignore);

		// Multiplos hits.
		RaycastHit[] allHits = Physics.RaycastAll(ray); // Ordenado por distância.
		int numOfHits = Physics.RaycastNonAlloc(ray, allHits); // Tamanho predefinido.
		for (int i = 0; i < numOfHits; i++)
		{
			// allHits[i]
		}

		// RaycastHit.
		Collider otherCollider = hitInfo.collider;
		Transform otherTransform = hitInfo.transform;
		Rigidbody otherRigidbody = hitInfo.rigidbody; // Pode ser null.
		Vector3 hitNormal = hitInfo.normal;
		Vector3 hitPoint = hitInfo.point;

		// Shape casts.
		bool boxCastHit = Physics.BoxCast(Vector3.zero, Vector3.one, Vector3.forward, out hitInfo, Quaternion.identity, 5f, LayerMask.NameToLayer("Terrain"), QueryTriggerInteraction.Ignore);
		bool sphereCastHit = Physics.SphereCast(Vector3.zero, 1, Vector3.forward, out hitInfo, 5f, LayerMask.NameToLayer("Terrain"), QueryTriggerInteraction.Ignore);
		bool capsuleCastHit = Physics.CapsuleCast(Vector3.zero, Vector3.up, 1, Vector3.forward, out hitInfo, 5f, LayerMask.NameToLayer("Terrain"), QueryTriggerInteraction.Ignore);

		// Cast All.
		RaycastHit[] boxCastHits = Physics.BoxCastAll(Vector3.zero, Vector3.one, Vector3.forward, Quaternion.identity, 5f, LayerMask.NameToLayer("Terrain"), QueryTriggerInteraction.Ignore);
		RaycastHit[] sphereCastHits = Physics.SphereCastAll(Vector3.zero, 1, Vector3.forward, 5f, LayerMask.NameToLayer("Terrain"), QueryTriggerInteraction.Ignore);
		RaycastHit[] capsuleCastHits = Physics.CapsuleCastAll(Vector3.zero, Vector3.up, 1, Vector3.forward, 5f, LayerMask.NameToLayer("Terrain"), QueryTriggerInteraction.Ignore);

		// Cast All NonAlloc.
		Physics.BoxCastNonAlloc(Vector3.zero, Vector3.one, Vector3.forward, boxCastHits, Quaternion.identity, 5f, LayerMask.NameToLayer("Terrain"), QueryTriggerInteraction.Ignore);
		Physics.SphereCastNonAlloc(Vector3.zero, 1, Vector3.forward, sphereCastHits, 5f, LayerMask.NameToLayer("Terrain"), QueryTriggerInteraction.Ignore);
		Physics.CapsuleCastNonAlloc(Vector3.zero, Vector3.up, 1, Vector3.forward, capsuleCastHits, 5f, LayerMask.NameToLayer("Terrain"), QueryTriggerInteraction.Ignore);

		// Check.
		bool boxCollided = Physics.CheckBox(Vector3.zero, Vector3.one, Quaternion.identity, LayerMask.NameToLayer("Terrain"), QueryTriggerInteraction.Ignore);
		bool sphereCollided = Physics.CheckSphere(Vector3.zero, 1, LayerMask.NameToLayer("Terrain"), QueryTriggerInteraction.Ignore);
		bool capsuleCollided = Physics.CheckCapsule(Vector3.zero, Vector3.up, 1, LayerMask.NameToLayer("Terrain"), QueryTriggerInteraction.Ignore);

		// Overlap.
		Collider[] boxOverlapedColliders = Physics.OverlapBox(Vector3.zero, Vector3.one, Quaternion.identity, LayerMask.NameToLayer("Terrain"), QueryTriggerInteraction.Ignore);
		Collider[] sphereOverlapedColliders = Physics.OverlapSphere(Vector3.zero, 1, LayerMask.NameToLayer("Terrain"), QueryTriggerInteraction.Ignore);
		Collider[] capsuleOverlapedColliders = Physics.OverlapCapsule(Vector3.zero, Vector3.up, 1, LayerMask.NameToLayer("Terrain"), QueryTriggerInteraction.Ignore);

		// Rigidbody
		var rigidbody = GetComponent<Rigidbody>();
		float rigidbodyMass = rigidbody.mass;
		bool isKinematic = rigidbody.isKinematic;
		Vector3 velocity = rigidbody.velocity;
		Vector3 position = rigidbody.position;
		// ...

		rigidbody.MovePosition(Vector3.one);
		rigidbody.MoveRotation(Quaternion.identity);

		rigidbody.AddForce(0, 1, 0, ForceMode.Force);
		rigidbody.AddTorque(1, 1, 1, ForceMode.VelocityChange);
		rigidbody.AddForceAtPosition(Vector3.one, Vector3.zero, ForceMode.Acceleration);
		rigidbody.AddExplosionForce(100, Vector3.zero, 5f, 2f, ForceMode.Impulse);

		rigidbody.AddRelativeForce(0, 1, 0, ForceMode.Force);
		rigidbody.AddRelativeTorque(1, 1, 1, ForceMode.Force);

		rigidbody.Sleep();
		rigidbody.WakeUp();
		rigidbody.IsSleeping();

		// Cast
		bool sweepHit = rigidbody.SweepTest(Vector3.forward, out hitInfo, 5f, QueryTriggerInteraction.Ignore);
		RaycastHit[] sweepHits = rigidbody.SweepTestAll(Vector3.forward, 5f, QueryTriggerInteraction.Ignore);

		// Tudo tem suas respetivas versões 2D.
		Collider2D collider2D = new Collider2D();
		BoxCollider2D boxCollider2D = new BoxCollider2D();
		CircleCollider2D circleCollider2D = new CircleCollider2D();
		CapsuleCollider2D capsuleCollider2D = new CapsuleCollider2D();

		EdgeCollider2D edgeCollider2D = new EdgeCollider2D(); // ~Terrain
		PolygonCollider2D polygonCollider2D = new PolygonCollider2D(); // ~Mesh

		CompositeCollider2D compositeCollider2D = new CompositeCollider2D();

		Physics2D.Raycast(Vector2.zero, Vector2.one);

		Rigidbody2D rigidbody2d = GetComponent<Rigidbody2D>();
		rigidbody2d.MovePosition(Vector2.right);
		// E assim vai...
	}

	public bool DrawCasts = true;

	private void Update()
	{
		if (DrawCasts)
		{
			Ray ray = new Ray(Vector3.left * 2 + Vector3.up * 5, Vector3.down);

			if (Physics.Raycast(ray, out var hitInfo, 5))
			{
				Debug.DrawLine(Vector3.left * 2 + Vector3.up * 5, hitInfo.point, Color.red);
				Debug.DrawLine(hitInfo.point, hitInfo.point + new Vector3(1, 1, 0) * 0.2f, Color.red);
				Debug.DrawLine(hitInfo.point, hitInfo.point + new Vector3(-1, 1, 0) * 0.2f, Color.red);
				hitInfo.collider.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.yellow);
			}
			else
			{
				Debug.DrawLine(Vector3.left * 2 + Vector3.up * 5, Vector3.left * 2 + Vector3.up * 5 + Vector3.down * 5, Color.yellow);
				Debug.DrawLine(Vector3.left * 2, Vector3.left * 2 + new Vector3(1, 1, 0) * 0.2f, Color.yellow);
				Debug.DrawLine(Vector3.left * 2, Vector3.left * 2 + new Vector3(-1, 1, 0) * 0.2f, Color.yellow);
			}

			if (Physics.BoxCast(Vector3.up * 5, Vector3.one / 2, Vector3.down, out var hitInfo2, Quaternion.identity, 5))
			{
				ExtDebug.DrawBoxCastBox(Vector3.up * 5, Vector3.one / 2, Quaternion.identity, Vector3.down, hitInfo2.distance, Color.yellow);
				ExtDebug.DrawBoxCastOnHit(Vector3.up * 5, Vector3.one / 2, Quaternion.identity, Vector3.down, hitInfo2.distance, Color.red);

				hitInfo2.collider.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.blue);
			}
			else
			{
				ExtDebug.DrawBoxCastBox(Vector3.up * 5, Vector3.one / 2, Quaternion.identity, Vector3.down, 5, Color.yellow);
			}

			if (Physics.CheckBox(Vector3.right * 2 + Vector3.up * 0.5f, Vector3.one * 0.5f, Quaternion.Euler(45, 45, 45)))
			{
				ExtDebug.DrawBox(Vector3.right * 2 + Vector3.up * 0.5f, Vector3.one * 0.5f, Quaternion.Euler(45, 45, 45), Color.red);
			}
			else
			{
				ExtDebug.DrawBox(Vector3.right * 2 + Vector3.up * 0.5f, Vector3.one * 0.5f, Quaternion.Euler(45, 45, 45), Color.yellow);
			}

			var colliders = Physics.OverlapBox(Vector3.right * 2 + Vector3.up * 0.5f, Vector3.one * 0.5f, Quaternion.Euler(45, 45, 45));

			foreach (var collider in colliders)
			{
				collider.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
			}
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		Debug.Log($"OnCollisionEnter: {collision.transform.name}");
	}

	private void OnCollisionStay(Collision collision)
	{
		Debug.Log($"OnCollisionStay: {collision.transform.name}");

		GameObject otherGameObject = collision.gameObject;
		Transform otherTransform = collision.transform;
		Collider otherCollider = collision.collider;
		Rigidbody otherRigidbody = collision.rigidbody; // Pode ser null.
		int numberOfContactPoints = collision.contactCount;
		Vector3 relativeVelocity = collision.relativeVelocity;
		Vector3 impulseUsedToResolveCollision = collision.impulse;
		ContactPoint[] contactPoints = collision.contacts;

		foreach (var contactPoint in contactPoints)
		{
			Collider thisCollider = contactPoint.thisCollider;
			Collider otherCollider2 = contactPoint.otherCollider;

			Vector3 normal = contactPoint.normal;
			Vector3 point = contactPoint.point;
			float distance = contactPoint.separation;

			Debug.DrawRay(point, normal, Color.cyan);
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		Debug.Log($"OnCollisionExit: {collision.transform.name}");
	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log($"OnTriggerEnter: {other.transform.name}");
	}

	private void OnTriggerStay(Collider other)
	{
		Debug.Log($"OnTriggerStay: {other.transform.name}");
	}

	private void OnTriggerExit(Collider other)
	{
		Debug.Log($"OnTriggerExit: {other.transform.name}");
	}

	private void OnCollisionEnter2D(Collision2D collision) { }
	private void OnCollisionStay2D(Collision2D collision) { }
	private void OnCollisionExit2D(Collision2D collision) { }

	private void OnTriggerEnter2D(Collider2D collision) { }
	private void OnTriggerStay2D(Collider2D collision) { }
	private void OnTriggerExit2D(Collider2D collision) { }
}
