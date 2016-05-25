using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

struct CubeState {
	public int moveNum;
	public Vector3 position;
}

public class CubePlayer : NetworkBehaviour {
	[SyncVar(hook="OnServerStateChanged")] CubeState serverState;
	CubeState predictedState;
	//Queue pendingMoves;
	CharacterController myController;

	public float moveSpeed = 3.0f;
	public float gravity = 9.81f;

	void Awake () {
		InitState();
	}

	void Start () {
		/* if (isLocalPlayer) {
			pendingMoves = new Queue();
		} */
		myController = gameObject.GetComponent<CharacterController>();
		SyncState();
	}

	void Update () {
		if (isLocalPlayer) {
			Vector3 movement = computeMovement ();
			//pendingMoves.Enqueue (movement);
			UpdatePredictedState (movement);
			CmdMoveOnServer ();
		} else {
			SyncState ();
		}
	}

	Vector3 computeMovement ()
	{
		Vector3 movementZ = Input.GetAxis("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime;

		// Determine how much should move in the x-direction
		Vector3 movementX = Input.GetAxis("Horizontal") * Vector3.right * moveSpeed * Time.deltaTime;

		// Convert combined Vector3 from local space to world space based on the position of the current gameobject (player)
		Vector3 movement = transform.TransformDirection(movementZ+movementX);

		// Apply gravity (so the object will fall if not grounded)
		movement.y -= gravity * Time.deltaTime;

		return movement;
	}

	[Server] void InitState () {
		serverState = new CubeState {
			moveNum = 0,
			position = new Vector3 (0,1,0)
		};
	}

	[Command] void CmdMoveOnServer ()
	{
		serverState = predictedState;
	}

	CubeState Move(CubeState previous, Vector3 movement) {
		myController.Move(movement);
		return new CubeState {
			moveNum = 1 + previous.moveNum,
			position = transform.position
		};
	}

	void UpdatePredictedState (Vector3 movement)
	{
		//predictedState = serverState;
		//foreach (Vector3 movement in pendingMoves) {
		predictedState = Move (predictedState, movement);
		//}
	}

	void OnServerStateChanged (CubeState newState)
	{
		serverState = newState;
		/*if (pendingMoves != null) {
			while (pendingMoves.Count > (predictedState.moveNum - serverState.moveNum)) {
				pendingMoves.Dequeue ();
			}
			UpdatePredictedState ();
		}
		*/
	}

	void SyncState () {
		if (!isLocalPlayer) {
			transform.position = serverState.position;
		}
	}
}
