using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Services.Commons.Dtos;
using Services.Linha;
using Xunit;

namespace Tests.ServicesTestes
{
    public class LinhaServiceTestes : BaseTeste
    {
        private readonly CadastrarLinha cadastrarLinha;
        private readonly EditarLinha editarLinha;
        private readonly DeletarLinha deletarLinha;
        private readonly ListarTodasAsLinhas listarTodasAsLinhas;
        private readonly ObterLinhaPorId obterLinhaPorId;
        private readonly ObterLinhasPorParada obterLinhasPorParada;
        private readonly VincularVeiculo vincularVeiculo;
        private readonly VincularParada vincularParada;
        private readonly DesvincularVeiculo desvincularVeiculo;
        private readonly DesvincularParada desvincularParada;

        public LinhaServiceTestes()
        {
            cadastrarLinha = new CadastrarLinha(context);
            editarLinha = new EditarLinha(context);
            deletarLinha = new DeletarLinha(context);
            listarTodasAsLinhas = new ListarTodasAsLinhas(context);
            obterLinhaPorId = new ObterLinhaPorId(context);
            obterLinhasPorParada = new ObterLinhasPorParada(context);
            vincularVeiculo = new VincularVeiculo(context);
            vincularParada = new VincularParada(context);
            desvincularVeiculo = new DesvincularVeiculo(context);
            desvincularParada = new DesvincularParada(context);
        }

        [Fact]
        public async Task DeveCadastrarUmaLinha()
        {
            //arrange
            var linhaDto = new LinhaDto() { Nome = "Linha 1" };

            //act
            await cadastrarLinha.Executar(linhaDto);

            var linhaFoiCadastrada = await context.Linhas.AnyAsync(x => x.Nome == linhaDto.Nome);

            //assert
            Assert.True(linhaFoiCadastrada);
        }

        [Fact]
        public async Task DeveEditarUmaLinha()
        {
            //arrange
            var linhaDto = new LinhaDto() { Id = 1, Nome = "Linha 2" };
            var linha = new Domain.Entities.Linha(
                  nome: "Linha 1",
                  id: 1
              );

            await context.AddAsync(linha);
            await context.SaveChangesAsync();

            context.Entry(linha).State = EntityState.Detached;

            //act
            await editarLinha.Executar(linhaDto);

            var linhaCadastrada = await context.Linhas.FindAsync(linha.Id);

            //assert
            Assert.Equal(linhaDto.Nome, linhaCadastrada.Nome);
        }

        [Fact]
        public async Task NaoDeveEditarUmaLinha()
        {
            //arrange
            var linhaDto = new LinhaDto() { Id = 2, Nome = "Linha 2" };
            var linha = new Domain.Entities.Linha(
                  nome: "Linha 1",
                  id: 1
              );

            await context.AddAsync(linha);
            await context.SaveChangesAsync();

            //act
            await editarLinha.Executar(linhaDto);

            //assert
            Assert.True(editarLinha.Notifications.ContainsKey("not-found"));
        }

        [Fact]
        public async Task DeveDeletarUmaLinha()
        {
            //arrange
            var linha = new Domain.Entities.Linha(
                  nome: "Linha 1",
                  id: 1
              );

            await context.AddAsync(linha);
            await context.SaveChangesAsync();

            //act
            await deletarLinha.Executar(id: 1);

            //assert
            Assert.False(deletarLinha.Notifications.Any());
        }

        [Fact]
        public async Task NaoDeveDeletarUmaLinha()
        {
            //arrange
            var linha = new Domain.Entities.Linha(
                  nome: "Linha 1",
                  id: 1
              );

            await context.AddAsync(linha);
            await context.SaveChangesAsync();

            //act
            await deletarLinha.Executar(id: 2);

            //assert
            Assert.True(deletarLinha.Notifications.ContainsKey("not-found"));
        }

        [Fact]
        public async Task DeveListarUmaLinha()
        {
            //arrange
            var linha = new Domain.Entities.Linha(
                  nome: "Linha 1",
                  id: 1
            );

            await context.AddAsync(linha);
            await context.SaveChangesAsync();

            //act
            var linhas = await listarTodasAsLinhas.Executar();

            //assert
            Assert.True(linhas.Count == 1);
        }

        [Fact]
        public async Task DeveListarUmaLinhaPorId()
        {
            //arrange
            var linha = new Domain.Entities.Linha(
                  nome: "Linha 1",
                  id: 1
              );

            await context.AddAsync(linha);
            await context.SaveChangesAsync();

            //act
            var linhaCadastrada = await obterLinhaPorId.Executar(id: 1);

            //assert
            Assert.NotNull(linhaCadastrada);
        }

        [Fact]
        public async Task DeveListarUmaLinhaPorIdDeUmaParada()
        {
            //arrange
            var parada = new Domain.Entities.Parada(
               nome: "Parada 1",
               new Domain.ValueObjects.Localizacao(
                   latitude: -8.771593,
                   longitude: -63.847208
               )
           );

            var linha = new Domain.Entities.Linha(
                  nome: "Linha 1",
                  id: 1
            );

            linha.AdicionarParada(parada);

            await context.AddAsync(parada);
            await context.AddAsync(linha);
            await context.SaveChangesAsync();

            //act
            var linhas = await obterLinhasPorParada.Executar(id: 1);

            //assert
            Assert.True(linhas.Count == 1);
        }

        [Fact]
        public async Task DeveListarUmaLinhaPorLocalizacaoDeUmaParada()
        {
            //arrange
            var parada = new Domain.Entities.Parada(
               nome: "Parada 1",
               new Domain.ValueObjects.Localizacao(
                   latitude: -8.771593,
                   longitude: -63.847208
               )
           );

            var linha = new Domain.Entities.Linha(
                  nome: "Linha 1",
                  id: 1
            );

            linha.AdicionarParada(parada);

            await context.AddAsync(parada);
            await context.AddAsync(linha);
            await context.SaveChangesAsync();

            //act
            var linhas = await obterLinhasPorParada.Executar(latitude: -8.771593, longitude: -63.847208);

            //assert
            Assert.True(linhas.Count == 1);
        }

        [Fact]
        public async Task DeveVincularUmVeiculoNaLinha()
        {
            //arrange
            var veiculoNaLinhaDto = new VeiculoNaLinhasDto() { LinhaId = 1, VeiculoId = 1 };

            var veiculoDto = new VeiculoDto() {
                Nome = "Veículo 1",
                Modelo = "Mercedes",
                Localizacao = new LocalizacaoDto() {
                    Latitude = -8.771593,
                    Longitude = -63.847208
                }
            };

            var veiculo = new Domain.Entities.Veiculo(
                 veiculoDto.Nome,
                 veiculoDto.Modelo,
                 new Domain.ValueObjects.Localizacao(
                     veiculoDto.Localizacao.Latitude,
                     veiculoDto.Localizacao.Longitude
                 )
            );

            var linha = new Domain.Entities.Linha(
                nome: "Linha 1",
                id: 1
            );

            linha.AdicionarVeiculo(veiculo);

            await context.AddAsync(veiculo);
            await context.AddAsync(linha);
            await context.SaveChangesAsync();

            //act
            await vincularVeiculo.Executar(veiculoNaLinhaDto);

            //assert
            Assert.False(vincularVeiculo.Notifications.Any());
        }

        [Fact]
        public async Task NaoDeveVincularUmVeiculoNaLinhaPoisALinhaNaoFoiEncontrada()
        {
            //arrange
            var veiculoNaLinhaDto = new VeiculoNaLinhasDto() { LinhaId = 2, VeiculoId = 1 };

            var veiculoDto = new VeiculoDto() {
                Nome = "Veículo 1",
                Modelo = "Mercedes",
                Localizacao = new LocalizacaoDto() {
                    Latitude = -8.771593,
                    Longitude = -63.847208
                }
            };

            var veiculo = new Domain.Entities.Veiculo(
                 veiculoDto.Nome,
                 veiculoDto.Modelo,
                 new Domain.ValueObjects.Localizacao(
                     veiculoDto.Localizacao.Latitude,
                     veiculoDto.Localizacao.Longitude
                 )
            );

            var linha = new Domain.Entities.Linha(
                nome: "Linha 1",
                id: 1
            );

            linha.AdicionarVeiculo(veiculo);

            await context.AddAsync(veiculo);
            await context.AddAsync(linha);
            await context.SaveChangesAsync();

            //act
            await vincularVeiculo.Executar(veiculoNaLinhaDto);

            //assert
            Assert.True(vincularVeiculo.Notifications.ContainsKey("linha-nao-encontrada"));
        }

        [Fact]
        public async Task NaoDeveVincularUmVeiculoNaLinhaPoisOVeiculoNaoFoiEncontrado()
        {
            //arrange
            var veiculoNaLinhaDto = new VeiculoNaLinhasDto() { LinhaId = 1, VeiculoId = 2 };

            var veiculoDto = new VeiculoDto() {
                Nome = "Veículo 1",
                Modelo = "Mercedes",
                Localizacao = new LocalizacaoDto() {
                    Latitude = -8.771593,
                    Longitude = -63.847208
                }
            };

            var veiculo = new Domain.Entities.Veiculo(
                 veiculoDto.Nome,
                 veiculoDto.Modelo,
                 new Domain.ValueObjects.Localizacao(
                     veiculoDto.Localizacao.Latitude,
                     veiculoDto.Localizacao.Longitude
                 )
            );

            var linha = new Domain.Entities.Linha(
                nome: "Linha 1",
                id: 1
            );

            linha.AdicionarVeiculo(veiculo);

            await context.AddAsync(veiculo);
            await context.AddAsync(linha);
            await context.SaveChangesAsync();

            //act
            await vincularVeiculo.Executar(veiculoNaLinhaDto);

            //assert
            Assert.True(vincularVeiculo.Notifications.ContainsKey("veiculo-nao-encontrado"));
        }

        [Fact]
        public async Task DeveVincularUmaParadaNaLinha()
        {
            //arrange
            var paradaNaLinhaDto = new ParadaNaLinhaDto() { LinhaId = 1, ParadaId = 1 };

            var paradaDto = new ParadaDto() {
                Nome = "Parada 1",
                Localizacao = new LocalizacaoDto() {
                    Latitude = -8.771593,
                    Longitude = -63.847208
                }
            };

            var parada = new Domain.Entities.Parada(
                 paradaDto.Nome,
                 new Domain.ValueObjects.Localizacao(
                     paradaDto.Localizacao.Latitude,
                     paradaDto.Localizacao.Longitude
                 )
            );

            var linha = new Domain.Entities.Linha(
                nome: "Linha 1",
                id: 1
            );

            await context.AddAsync(parada);
            await context.AddAsync(linha);
            await context.SaveChangesAsync();

            //act
            await vincularParada.Executar(paradaNaLinhaDto);

            //assert
            Assert.False(vincularParada.Notifications.Any());
        }

        [Fact]
        public async Task NaoDeveVincularUmaParadaNaLinhaPoisALinhaNaoFoiEncontrada()
        {
            //arrange
            var paradaNaLinhaDto = new ParadaNaLinhaDto() { LinhaId = 2, ParadaId = 1 };

            var paradaDto = new ParadaDto() {
                Nome = "Parada 1",
                Localizacao = new LocalizacaoDto() {
                    Latitude = -8.771593,
                    Longitude = -63.847208
                }
            };

            var parada = new Domain.Entities.Parada(
                 paradaDto.Nome,
                 new Domain.ValueObjects.Localizacao(
                     paradaDto.Localizacao.Latitude,
                     paradaDto.Localizacao.Longitude
                 ),
                 id: 1
            );

            var linha = new Domain.Entities.Linha(
                nome: "Linha 1",
                id: 1
            );

            await context.AddAsync(parada);
            await context.AddAsync(linha);
            await context.SaveChangesAsync();

            //act
            await vincularParada.Executar(paradaNaLinhaDto);

            //assert
            Assert.True(vincularParada.Notifications.ContainsKey("linha-nao-encontrada"));
        }

        [Fact]
        public async Task NaoDeveVincularUmaParadaNaLinhaPoisAParadaNaoFoiEncontrada()
        {
            //arrange
            var paradaNaLinhaDto = new ParadaNaLinhaDto() { LinhaId = 1, ParadaId = 2 };

            var paradaDto = new ParadaDto() {
                Nome = "Parada 1",
                Localizacao = new LocalizacaoDto() {
                    Latitude = -8.771593,
                    Longitude = -63.847208
                }
            };

            var parada = new Domain.Entities.Parada(
                 paradaDto.Nome,
                 new Domain.ValueObjects.Localizacao(
                     paradaDto.Localizacao.Latitude,
                     paradaDto.Localizacao.Longitude
                 ),
                 id: 1
            );

            var linha = new Domain.Entities.Linha(
                nome: "Linha 1",
                id: 1
            );

            await context.AddAsync(parada);
            await context.AddAsync(linha);
            await context.SaveChangesAsync();

            //act
            await vincularParada.Executar(paradaNaLinhaDto);

            //assert
            Assert.True(vincularParada.Notifications.ContainsKey("parada-nao-encontrada"));
        }

        [Fact]
        public async Task NaoDeveVincularUmaParadaNaLinhaPoisAParadaJaEstaVinculada()
        {
            //arrange
            var paradaNaLinhaDto = new ParadaNaLinhaDto() { LinhaId = 1, ParadaId = 2 };

            var paradaDto = new ParadaDto() {
                Nome = "Parada 1",
                Localizacao = new LocalizacaoDto() {
                    Latitude = -8.771593,
                    Longitude = -63.847208
                }
            };

            var parada = new Domain.Entities.Parada(
                 paradaDto.Nome,
                 new Domain.ValueObjects.Localizacao(
                     paradaDto.Localizacao.Latitude,
                     paradaDto.Localizacao.Longitude
                 )
            );

            var linha = new Domain.Entities.Linha(
                nome: "Linha 1",
                id: 1
            );

            linha.AdicionarParada(parada);

            await context.AddAsync(parada);
            await context.AddAsync(linha);
            await context.SaveChangesAsync();

            //act
            await vincularParada.Executar(paradaNaLinhaDto);

            //assert
            Assert.False(vincularParada.Notifications.ContainsKey("parada-vinculada"));
        }

        [Fact]
        public async Task DeveDesvincularUmVeiculoNaLinha()
        {
            //arrange
            var veiculoDto = new VeiculoDto() {
                Nome = "Veículo 1",
                Modelo = "Mercedes",
                Localizacao = new LocalizacaoDto() {
                    Latitude = -8.771593,
                    Longitude = -63.847208
                }
            };

            var veiculo = new Domain.Entities.Veiculo(
                 veiculoDto.Nome,
                 veiculoDto.Modelo,
                 new Domain.ValueObjects.Localizacao(
                     veiculoDto.Localizacao.Latitude,
                     veiculoDto.Localizacao.Longitude
                 )
            );

            var linha = new Domain.Entities.Linha(
                nome: "Linha 1",
                id: 1
            );

            linha.AdicionarVeiculo(veiculo);

            await context.AddAsync(veiculo);
            await context.AddAsync(linha);
            await context.SaveChangesAsync();

            //act
            await desvincularVeiculo.Executar(id: 1);

            //assert
            Assert.True(linha.Veiculos.Count == 0);
        }

        [Fact]
        public async Task DeveDesvincularUmaParadaNaLinha()
        {
            //arrange
            var paradaDto = new ParadaDto() {
                Nome = "Parada 1",
                Localizacao = new LocalizacaoDto() {
                    Latitude = -8.771593,
                    Longitude = -63.847208
                }
            };

            var parada = new Domain.Entities.Parada(
                 paradaDto.Nome,
                 new Domain.ValueObjects.Localizacao(
                     paradaDto.Localizacao.Latitude,
                     paradaDto.Localizacao.Longitude
                 )
            );

            var linha = new Domain.Entities.Linha(
                nome: "Linha 1",
                id: 1
            );

            linha.AdicionarParada(parada);

            await context.AddAsync(parada);
            await context.AddAsync(linha);
            await context.SaveChangesAsync();

            //act
            await desvincularParada.Executar(linha.Id, parada.Id);

            //assert
            Assert.True(linha.Paradas.Count == 0);
        }
    }
}