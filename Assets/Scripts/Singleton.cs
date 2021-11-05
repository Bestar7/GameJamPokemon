using UnityEngine;

public abstract class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T>
{
    [SerializeField] private bool isPersistent;
    private static T _instance;
    public static T instance => _instance;

    protected virtual void Awake()
    {
        if (!_instance)
        {
            _instance = (T)this;
            DontDestroyOnLoad(this);
			if (transform != null)
				DontDestroyOnLoad(transform.gameObject);
        }
		else
		{	// TODO pour le menu princpial : commencer par une scene[0] avec uniquement GameManager (on y retourn plus jamais !!!) ; scene[1] est le menu principal
			Debug.Log(this.name + " singleton est déjà présent => suppression d'un d'eux");
			if (transform != null)
				Destroy(transform.gameObject);
		}
    }
}