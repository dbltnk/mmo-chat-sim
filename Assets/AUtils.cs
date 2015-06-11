using UnityEngine;
using System.Collections;

namespace AUtils {

	public class Utilities : MonoBehaviour {

		public static string Capitalize(string sourceStr)
		{
			sourceStr.Trim();
			if (!string.IsNullOrEmpty(sourceStr))
			{
				char[] allCharacters = sourceStr.ToCharArray();
				
				for (int i = 0; i < allCharacters.Length; i++)
				{
					char character = allCharacters[i];
					if (i == 0)
					{
						if (char.IsLower(character))
						{
							allCharacters[i] = char.ToUpper(character);
						}
					}
				}
				return new string(allCharacters);
			}
			return sourceStr;
		}
	}
}