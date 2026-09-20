using UnityEngine;


[CreateAssetMenu(fileName = "NewCharacter", menuName = "VisualNovel/Character")]
public class CharacterData : ScriptableObject
{
    [Header("Info Dasar")]
    public string characterName;

    [Tooltip("Warna nama karakter saat ditampilkan di dialog box (opsional)")]
    public Color nameColor = Color.white;

    [Header("Ekspresi / Pose")]
    [Tooltip("Kumpulan sprite ekspresi karakter, misalnya: Normal, Senang, Sedih, Marah")]
    public CharacterExpression[] expressions;

    // Fungsi bantu untuk cari sprite berdasarkan nama ekspresi
    public Sprite GetExpression(string expressionName)
    {
        foreach (var exp in expressions)
        {
            if (exp.expressionName == expressionName)
                return exp.sprite;
        }

        Debug.LogWarning($"Ekspresi '{expressionName}' tidak ditemukan untuk karakter {characterName}");
        return null;
    }
}

[System.Serializable]
public class CharacterExpression
{
    public string expressionName; // contoh: "Normal", "Senang", "Sedih"
    public Sprite sprite;
}
