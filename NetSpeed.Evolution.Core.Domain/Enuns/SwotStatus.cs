namespace NetSpeed.Evolution.Core.Domain.Enuns;

public enum SwotStatus
{
    Available = 1, // Disponível para o colaborador preencher
    Draft = 2,  // Quando o colaborador preenche e salva, mas não envia para o superior.
    Sent = 3, // Quando o colaborador envia para o superior.
    ReturnedReview = 4, // Quando o superior revisa e devvolve para o colaborador.
    Revised = 5, // Quando o superior revisa porém não concluí.
    Completed = 6, // Quando o superior revisa e concluí.
}
