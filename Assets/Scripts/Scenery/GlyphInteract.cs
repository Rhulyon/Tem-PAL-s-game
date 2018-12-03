using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlyphInteract : MonoBehaviour
{
    public List<SpawnGlyph> ListOfSpawn = new List<SpawnGlyph>();

    private void Start()
    {
        if (ListOfSpawn.Count == 0)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Velma")
        {
            foreach (SpawnGlyph lsp in ListOfSpawn)
            {
                if (lsp.MakeAppear == false)
                {
                    Destroy(lsp.SpawnOrDispawn);
                }
                else
                {
                    Instantiate(lsp.SpawnOrDispawn, lsp.trans.position, Quaternion.identity);
                }
            }
        }
    }
}

[System.Serializable]
public class SpawnGlyph
{
    public bool MakeAppear;
    public GameObject SpawnOrDispawn;
    public Transform trans;
}
