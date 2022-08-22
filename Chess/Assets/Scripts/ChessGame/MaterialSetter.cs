using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class MaterialSetter : MonoBehaviour
{
	private MeshRenderer meshRenderer;
	public MeshRenderer MeshRenderer
	{
		get
		{
			if (meshRenderer == null)
				meshRenderer = GetComponent<MeshRenderer>();
			return meshRenderer;
		}
	}

	public void SetSingleMaterial(Material mat)
	{
		MeshRenderer.material = mat;
	}
}