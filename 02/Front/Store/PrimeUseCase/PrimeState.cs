using Core;
using Fluxor;

namespace Front.Store.PrimeUseCase;

[FeatureState]
public record PrimeState(int Min, int Max)
{
  public List<int> PrimeNumbers
  {
    get => PrimeNumberGenerator.GeneratePrimeNumbers(Min, Max);
  }

  public PrimeState() : this(2, 2)
  { }
}