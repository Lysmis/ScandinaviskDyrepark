using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class TilemapBaker : MonoBehaviour
{ 
   
    [MenuItem("Tools/Bake Selected Tilemap")]
    public static void BakeSelectedTilemap()
    {
        GameObject go = Selection.activeGameObject;
        if (go == null || go.GetComponent<Tilemap>() == null)
        {
            Debug.LogError("Vælg et GameObject med en Tilemap først!");
            return;
        }

        Tilemap tilemap = go.GetComponent<Tilemap>();
        TilemapRenderer renderer = go.GetComponent<TilemapRenderer>();
        if (renderer == null)
        {
            Debug.LogError("Tilemap skal have en TilemapRenderer!");
            return;
        }

        // Brug Camera til at "tegne" tilemap som RenderTexture
        BoundsInt bounds = tilemap.cellBounds;
        Vector3Int size = bounds.size;

        int pixelsPerUnit = 32; // tilpas til dit projekt
        int width = size.x * pixelsPerUnit;
        int height = size.y * pixelsPerUnit;

        RenderTexture rt = new RenderTexture(width, height, 24);
        Texture2D tex = new Texture2D(width, height, TextureFormat.ARGB32, false);

        // Midlertidigt kamera
        GameObject camGO = new GameObject("TilemapBakeCamera");
        Camera cam = camGO.AddComponent<Camera>();
        cam.orthographic = true;
        cam.orthographicSize = size.y / 2f;
        cam.transform.position = new Vector3(bounds.center.x, bounds.center.y, -10);
        cam.clearFlags = CameraClearFlags.Color;
        cam.backgroundColor = new Color(0, 0, 0, 0); // gennemsigtig
        cam.targetTexture = rt;

        // Render til RenderTexture
        cam.Render();

        // Kopiér fra RenderTexture til Texture2D
        RenderTexture.active = rt;
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();

        // Ryd op
        RenderTexture.active = null;
        cam.targetTexture = null;
        Object.DestroyImmediate(camGO);
        Object.DestroyImmediate(rt);

        // Gem som PNG i Content/BakedTiles
        string path = $"Assets/Content/Tiling/BakedTiles/BakedTilemap.png";
        System.IO.File.WriteAllBytes(path, tex.EncodeToPNG());
        AssetDatabase.Refresh();

        // Importér som Sprite
        TextureImporter importer = AssetImporter.GetAtPath(path) as TextureImporter;
        if (importer != null)
        {
            importer.textureType = TextureImporterType.Sprite;
            importer.spritePixelsPerUnit = pixelsPerUnit;
            importer.SaveAndReimport();
        }

        Debug.Log("Tilemap baked til: " + path);
    }
}

