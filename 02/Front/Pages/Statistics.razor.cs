using Fluxor;
using Front.Store.StatisticsUseCase;
using Microsoft.AspNetCore.Components;

namespace Front.Pages;

public partial class Statistics
{
  [Inject]
  private IState<StatisticsState> StatisticsState { get; set; }

  [Inject]
  public IDispatcher Dispatcher { get; set; }

  private void ChangeInput(int input)
  {
    Dispatcher.Dispatch(new InputChangeAction(input));
  }

  private void NewItem(int item)
  {
    Dispatcher.Dispatch(new NewItemAction(item));
  }

  private void DeleteItem(int pos)
  {
    Dispatcher.Dispatch(new DeleteItemAction(pos));
  }

  private void ChangeCurrent(int current)
  {
    Dispatcher.Dispatch(new CurrentChangeAction(current));
  }
}