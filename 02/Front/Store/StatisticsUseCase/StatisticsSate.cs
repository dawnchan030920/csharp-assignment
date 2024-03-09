using Fluxor;

namespace Front.Store.StatisticsUseCase;

[FeatureState]
public record StatisticsState(int Input, List<int> Ints, int Current)
{
  public StatisticsState() : this(default, [], default)
  { }
}