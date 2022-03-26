using UnityEngine;

public abstract class WeaponComponet: MonoBehaviour
{
   protected Weapon _weapon;

    protected abstract void WeaponFired();

    // Start is called before the first frame update

    private void Awake()
    {
        _weapon = GetComponent<Weapon>();
        _weapon.onFire += WeaponFired;
    }


    private void OnDestroy()
    {
        _weapon.onFire -= WeaponFired;
    }
}