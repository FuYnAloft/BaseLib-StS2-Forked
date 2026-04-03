using MegaCrit.Sts2.Core.Modding;
using MegaCrit.Sts2.Core.Models;

namespace BaseLib.Abstracts;

/// <summary>
/// Model that will passively receive hooks at all times.
/// </summary>
public abstract class CustomSingletonModel : SingletonModel, ICustomModel
{
    /// <summary>
    /// This property seems effectively unused; it is set anyways in case of future changes.
    /// </summary>
    public override bool ShouldReceiveCombatHooks { get; }

    public CustomSingletonModel(bool receiveCombatHooks, bool receiveRunHooks)
    {
        ShouldReceiveCombatHooks = receiveCombatHooks;
        if (receiveCombatHooks)
            ModHelper.SubscribeForCombatStateHooks(Id.Entry, _ => [this]);
        if (receiveRunHooks)
            ModHelper.SubscribeForRunStateHooks(Id.Entry, _ => [this]);
    }
}