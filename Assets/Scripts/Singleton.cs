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
		else {
			Debug.Log(this.name + " singleton est déjà présent, suppression du plus récent");
			Destroy(transform.gameObject);
		}
    }
}