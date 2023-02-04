using UnityEngine;

namespace Script.Factory.Character.Builder
{
    public class CharacterBuildDirector
    {
        public static ICharacter Construct(ICharacterBuilder builder)
        {
            
            builder.AddCharacterAttr(); 
            builder.AddGameObject();
            builder.AddWeapon();

            return builder.GetCharacter();
        }
    }
}