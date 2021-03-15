using Microsoft.EntityFrameworkCore;
using System.Linq;
using TesteDesenvolvedor.Domain;

namespace TesteDesenvolvedor.Repository.Context
{
    public class SeedingData
    {
        private DataContext _context;

        public SeedingData(DataContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Paradas.Any() || _context.Linhas.Any() || _context.Veiculos.Any())
            {
                return;
            }
            //Linhas
            Linha linha = new Linha { Nome = "LINHA 8000-10 TERM. LAPA / PÇA. RAMOS DE AZEVEDO" };
            Parada parada = new Parada { Nome = "ANGELICA B/C", Latitude = -23.534564, Longitude = -46.654302 };
            Parada parada1 = new Parada { Nome = "PARADA PALMEIRAS B/C", Latitude = -23.525799, Longitude = -46.679251 };
            Parada parada2 = new Parada { Nome = "ANTARTICA B/C", Latitude = -23.526523, Longitude = -46.673588 };
            Parada parada3 = new Parada { Nome = "BABY BARIONY B/C", Latitude = -23.528131, Longitude = -46.670652 };
            Parada parada4 = new Parada { Nome = "PQ. DA ÁGUA BRANCA B/C", Latitude = -23.53021, Longitude = -46.6669 };
            Parada parada5 = new Parada { Nome = "SCIPIAO B/C", Latitude = -23.52494, Longitude = -46.698995 };
            Parada parada6 = new Parada { Nome = "VESPASIANO B/C", Latitude = -23.524994, Longitude = -46.695297 };
            Parada parada7 = new Parada { Nome = "CORNELIA", Latitude = -23.525029, Longitude = -46.690074 };
            Parada parada8 = new Parada { Nome = "CATAO B/C", Latitude = -23.523409, Longitude = -46.700503 };
            Parada parada9 = new Parada { Nome = "SESC POMPEIA B/C", Latitude = -23.52517, Longitude = -46.683408 };
            Parada parada10 = new Parada { Nome = "VITORIA B/C", Latitude = -23.540545, Longitude = -46.643624 };
            Parada parada11 = new Parada { Nome = "ROSA E SILVA B/C", Latitude = -23.532847, Longitude = -46.657404 };
            Parada parada12 = new Parada { Nome = "ANA CINTRA B/C", Latitude = -23.538708, Longitude = -46.646888 };
            Parada parada13 = new Parada { Nome = "PACAEMBU B/C", Latitude = -23.532068, Longitude = -46.660957 };
            Parada parada14 = new Parada { Nome = "NOTHMANN B/C", Latitude = -23.536318, Longitude = -46.651201 };
            LinhaParada lp = new LinhaParada{Linha = linha, Parada = parada};
            LinhaParada lp1 = new LinhaParada{Linha = linha, Parada = parada1};
            LinhaParada lp2 = new LinhaParada{Linha = linha, Parada = parada2};
            LinhaParada lp3 = new LinhaParada{Linha = linha, Parada = parada3};
            LinhaParada lp4 = new LinhaParada{Linha = linha, Parada = parada4};
            LinhaParada lp5 = new LinhaParada{Linha = linha, Parada = parada5};
            LinhaParada lp6 = new LinhaParada{Linha = linha, Parada = parada6};
            LinhaParada lp7 = new LinhaParada{Linha = linha, Parada = parada7};
            LinhaParada lp8 = new LinhaParada{Linha = linha, Parada = parada8};
            LinhaParada lp9 = new LinhaParada{Linha = linha, Parada = parada9};
            LinhaParada lp10 = new LinhaParada{Linha = linha, Parada = parada10};
            LinhaParada lp11 = new LinhaParada{Linha = linha, Parada = parada11};
            LinhaParada lp12 = new LinhaParada{Linha = linha, Parada = parada12};
            LinhaParada lp13 = new LinhaParada{Linha = linha, Parada = parada13};
            LinhaParada lp14  = new LinhaParada{Linha = linha, Parada = parada14};
            Veiculo veiculo = new Veiculo { Nome = "8000-10", Modelo = "MERCEDES BENZ", Linha = linha };
            PosicaoVeiculo ps = new PosicaoVeiculo { Latitude = -23.54216975, Longitude = -46.64256675, Veiculo = veiculo };
            Veiculo veiculo2 = new Veiculo { Nome = "8000-10", Modelo = "Volkswagen",  Linha = linha  };
            PosicaoVeiculo ps2 = new PosicaoVeiculo { Latitude = -23.5381555, Longitude = -46.6478805, Veiculo = veiculo2 };


            Linha linha2 = new Linha { Nome = "LINHA 6001-10 - TERM.CAPELINHA"};
            Parada parada15 = new Parada {Nome = "PARADA NICOLINO BARRA C/B", Latitude = -23.651596, Longitude = -46.75776};
            Parada parada16 = new Parada {Nome = "PARADA AABB C/B", Latitude = -23.649137, Longitude = -46.752335};
            Parada parada17 = new Parada {Nome = "PARADA HOSPITAL CAMPO LIMPO C/B", Latitude = -23.64821, Longitude = -46.748814};
            Parada parada18 = new Parada {Nome = "PARADA CÍCERO JOSÉ SARAIVA C/B", Latitude = -23.645435, Longitude = -46.746334};
            Parada parada19 = new Parada {Nome = "PARADA CONDE DE ITU C/B", Latitude = -23.645569, Longitude = -46.704375};
            Parada parada20 = new Parada {Nome = "PARADA ANTÔNIO BANDEIRA C/B", Latitude = -23.64609, Longitude = -46.709177};
            Parada parada21 = new Parada {Nome = "PARADA OSWALDO DE ANDRADE C/B", Latitude = -23.645365, Longitude = -46.712884};
            Parada parada22 = new Parada {Nome = "PARADA JOSÉ DE SÁ C/B", Latitude = -23.644815, Longitude = -46.71857};
            Parada parada23 = new Parada {    Nome = "PARADA CENTRO AFRICANA C/B", Latitude = -23.644778, Longitude = -46.721813};
            LinhaParada lp15 = new LinhaParada{Linha = linha2, Parada = parada15};
            LinhaParada lp16 = new LinhaParada{Linha = linha2, Parada = parada16};
            LinhaParada lp17 = new LinhaParada{Linha = linha2, Parada = parada17};
            LinhaParada lp18 = new LinhaParada{Linha = linha2, Parada = parada18};
            LinhaParada lp19 = new LinhaParada{Linha = linha2, Parada = parada19};
            LinhaParada lp20 = new LinhaParada{Linha = linha2, Parada = parada20};
            LinhaParada lp21 = new LinhaParada{Linha = linha2, Parada = parada21};
            LinhaParada lp22 = new LinhaParada{Linha = linha2, Parada = parada22};
            LinhaParada lp23 = new LinhaParada{Linha = linha2, Parada = parada23};
            Veiculo veiculo3 = new Veiculo {Nome = "6001-10", Modelo = "MERCEDES BENZ", Linha = linha2};
            PosicaoVeiculo ps3 = new PosicaoVeiculo { Latitude = -23.64482675, Longitude = -46.718166499999995, Veiculo = veiculo3 };


            Linha linha3 = new Linha { Nome = "LINHA N104-11 TERM. PIRITUBA / TERM. LAPA" };
            Parada p = new Parada {Nome = "FREGUESIA B/C", Latitude = -23.494786, Longitude = -46.708775};
            Parada p1 = new Parada {Nome = "MARGINAL B/C", Latitude = -23.511052, Longitude = -46.705493};
            Parada p2 = new Parada {Nome = "JOSE MARIA B/C", Latitude = -23.514036, Longitude = -46.702259};
            Parada p3 = new Parada {Nome = "ZANELLA B/C", Latitude = -23.516592, Longitude = -46.698575};
            Parada p4 = new Parada {Nome = "PINEL B/C", Latitude = -23.485948, Longitude = -46.724827};
            Parada p5 = new Parada {Nome = "GUERINO B/C", Latitude = -23.484536, Longitude = -46.722711};
            Parada p6 = new Parada {Nome = "MANOEL BARBOSA B/C", Latitude = -23.488228, Longitude = -46.713496};
            Parada p7 = new Parada {Nome = "CABO ADAO B/C", Latitude = -23.48431, Longitude = -46.716271};
            Parada p8 = new Parada {Nome = "PRAÇA YARA B/C", Latitude = -23.48246, Longitude = -46.717675};
            Parada p9 = new Parada {Nome = "MIGUEL DE CASTRO", Latitude = -23.482531, Longitude = -46.72085};
            Parada p10 = new Parada {Nome = "RIO VERDE B/C", Latitude = -23.490768, Longitude = -46.710252};
            Parada p11 = new Parada {Nome = "PETRONIO PORTELA B/C", Latitude = -23.498233, Longitude = -46.706861};
            Parada p12 = new Parada {Nome = "PAULA FERREIRA B/C", Latitude = -23.500896, Longitude = -46.706633};
            Parada p13 = new Parada {Nome = "PIQUERI B/C", Latitude = -23.50616, Longitude = -46.706061};
            LinhaParada lp24 = new LinhaParada{Linha = linha3, Parada = p1};
            LinhaParada lp25 = new LinhaParada{Linha = linha3, Parada = p2};
            LinhaParada lp26 = new LinhaParada{Linha = linha3, Parada = p3};
            LinhaParada lp27 = new LinhaParada{Linha = linha3, Parada = p4};
            LinhaParada lp28 = new LinhaParada{Linha = linha3, Parada = p5};
            LinhaParada lp29 = new LinhaParada{Linha = linha3, Parada = p6};
            LinhaParada lp30 = new LinhaParada{Linha = linha3, Parada = p7};
            LinhaParada lp31 = new LinhaParada{Linha = linha3, Parada = p8};
            LinhaParada lp32 = new LinhaParada{Linha = linha3, Parada = p9};
            LinhaParada lp33 = new LinhaParada{Linha = linha3, Parada = p10};
            LinhaParada lp34 = new LinhaParada{Linha = linha3, Parada = p11};
            LinhaParada lp35 = new LinhaParada{Linha = linha3, Parada = p12};
            LinhaParada lp36 = new LinhaParada{Linha = linha3, Parada = p13};
            Veiculo veiculo4 = new Veiculo {Nome = "N104-11", Modelo = "MERCEDES BENZ", Linha = linha3};
            PosicaoVeiculo ps4 = new PosicaoVeiculo { Latitude = -23.5198475, Longitude = -46.700419, Veiculo = veiculo4 };

            Linha linha4 = new Linha { Nome = "LINHA 178T-10 METRÔ SANTANA / CEASA"};
            LinhaParada lp37 = new LinhaParada{Linha = linha4, Parada = p1};
            LinhaParada lp38 = new LinhaParada{Linha = linha4, Parada = p2};
            LinhaParada lp39 = new LinhaParada{Linha = linha4, Parada = p3};
            LinhaParada lp40 = new LinhaParada{Linha = linha4, Parada = p12};
            LinhaParada lp41 = new LinhaParada{Linha = linha4, Parada = p13};
            Veiculo veiculo5 = new Veiculo {Nome = "178T-10", Modelo = "MERCEDES BENZ", Linha = linha4};
            PosicaoVeiculo ps5 = new PosicaoVeiculo { Latitude = -23.52803875, Longitude = -46.73361125, Veiculo = veiculo5 };

            _context.Linhas.AddRange(linha, linha2, linha3, linha4);

            _context.Paradas.AddRange(parada, parada1, parada2, parada3, parada4, parada5, parada6,parada7, parada8,
            parada9, parada10,parada11,parada12,parada13,parada14,parada15,parada16,parada17,parada18,parada19,parada20,
            parada21,parada22,parada23, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11,p12,p13);

            _context.LinhasParadas.AddRange(lp, lp1, lp2, lp3, lp4, lp5, lp6,lp7, lp8,
            lp9, lp10,lp11,lp12,lp13,lp14,lp15,lp16,lp17,lp18,lp19,lp20,
            lp21,lp22,lp23, lp24, lp25, lp26, lp27, lp28,lp29,lp30,lp31,lp32,lp33,lp34,lp35,lp36,lp37,lp38,lp39,lp40,
            lp41);

            _context.Veiculos.AddRange(veiculo, veiculo2, veiculo3, veiculo4, veiculo5);

            _context.PosicaoVeiculos.AddRange(ps, ps2, ps3, ps4, ps5);

            _context.SaveChanges();
        }
    }
}
