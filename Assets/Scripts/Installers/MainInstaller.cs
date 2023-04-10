using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller
{
    [SerializeField] private PoolItem _pool;

    public override void InstallBindings()
    { 
        Container
            .Bind<PoolItem>() 
            .FromInstance(_pool) 
            .AsSingle();          
    }
}