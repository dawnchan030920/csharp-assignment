using Fluxor;
using Front.Store.PrimeUseCase;
using Microsoft.AspNetCore.Components;

namespace Front.Pages;

public partial class Prime
{
  [Inject]
  private IState<PrimeState> PrimeState { get; set; }

  [Inject]
  public IDispatcher Dispatcher { get; set; }

  private void ChangeMinValue(int value)
  {
    Dispatcher.Dispatch(new MinChangeAction(value));
  }

  private void ChangeMaxValue(int value)
  {
    Dispatcher.Dispatch(new MaxChangeAction(value));
  }
}