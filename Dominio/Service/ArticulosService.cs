using Data.Interfaces;
using DTOs;

namespace Dominio.Service;

public class ArticulosService
{
    private readonly IAutorRepository _autorRepository;
    private readonly IArticulosRepository _articulosRepository;

    public ArticulosService(IArticulosRepository articulosRepository, IAutorRepository autorRepository)
    {
        _articulosRepository = articulosRepository;
        _autorRepository = autorRepository;
    }

    public Articulo InsertarArticulo(string contenido, string titulo, int autorId)
    {
        if (!_autorRepository.AutorValido(autorId))
        {
            throw new Exception("Autor no válido");
        }

        var articuloId = _articulosRepository.InsertarArticulo(contenido, titulo, autorId);
        return ConsultarArticulo(articuloId);
    }

    public Articulo ConsultarArticulo(int id)
    {
        return _articulosRepository.GetArticulo(id);
    }
}