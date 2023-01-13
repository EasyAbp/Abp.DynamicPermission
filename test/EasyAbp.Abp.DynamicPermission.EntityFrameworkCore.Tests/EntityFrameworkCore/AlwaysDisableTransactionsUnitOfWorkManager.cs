using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;

namespace EasyAbp.Abp.DynamicPermission.EntityFrameworkCore;

// todo: wait for https://github.com/abpframework/abp/pull/15347
[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(IUnitOfWorkManager))]
public class AlwaysDisableTransactionsUnitOfWorkManager : IUnitOfWorkManager, ITransientDependency
{
    private readonly UnitOfWorkManager _unitOfWorkManager;

    public AlwaysDisableTransactionsUnitOfWorkManager(UnitOfWorkManager unitOfWorkManager)
    {
        _unitOfWorkManager = unitOfWorkManager;
    }

    public IUnitOfWork Current => _unitOfWorkManager.Current;

    public IUnitOfWork Begin(AbpUnitOfWorkOptions options, bool requiresNew = false)
    {
        options.IsTransactional = false;
        return _unitOfWorkManager.Begin(options, requiresNew);
    }

    public IUnitOfWork Reserve(string reservationName, bool requiresNew = false)
    {
        return _unitOfWorkManager.Reserve(reservationName, requiresNew);
    }

    public void BeginReserved(string reservationName, AbpUnitOfWorkOptions options)
    {
        options.IsTransactional = false;
        _unitOfWorkManager.BeginReserved(reservationName, options);
    }

    public bool TryBeginReserved(string reservationName, AbpUnitOfWorkOptions options)
    {
        options.IsTransactional = false;
        return _unitOfWorkManager.TryBeginReserved(reservationName, options);
    }
}