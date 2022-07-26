using AppCadastroSeries.Repositories;
using AppCadastroSeries.Enum;
using System;
using AppCadastroSeries.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;

namespace AppCadastroSeries.GraphicInterface
{
    public class Methods
    {
        static TvShowRepository repositorio = new TvShowRepository();
        static Genres genero = new Genres();
        public static void Manipulating()
        {
            var userOption = GetUserOption().ToUpper();

            if (userOption.ToUpper() == "x".ToUpper())
            {
                ClearConsole();
                Console.WriteLine("Saindo... Obrigado por usar nosso programa!");
                Environment.Exit(0);
            }

            var options = new List<string> { "1", "2", "3", "4", "5", "6", "x" };


            while (userOption.ToUpper() != "x".ToUpper())
            {
                if (!options.Contains(userOption))
                {
                    Console.WriteLine("Opção inválida");
                    Manipulating();
                }
                if (userOption == "1") GetListTv();

                if (userOption == "2") GetTvShowById();

                if (userOption == "3") InsertNewSerie();

                if (userOption == "4") UpdateSerie();

                if (userOption == "5") DeleteTvShow();

                if (userOption == "6") ClearConsole();

                Manipulating();
                return;
            }

        }

        public static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine($"-__Locadora Digital__-{Environment.NewLine}" +
                $"Informe a ação desejada: {Environment.NewLine}" +
                $"1 - Listar séries{Environment.NewLine}" +
                $"2 - Visualizar série{Environment.NewLine}" +
                $"3 - Inserir série{Environment.NewLine}" +
                $"4 - Atualizar série{Environment.NewLine}" +
                $"5 - Excluir série{Environment.NewLine}" +
                $"6 - Limpar tela{Environment.NewLine}" +
                $"x - Sair{ Environment.NewLine}");

            Console.Write("Sua opção: ");
            var userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;

        }

        private static void UpdateSerie()
        {
            try
            {
                Console.Write("Informe o ID da série a qual será atualizada: ");
                var inputedID = int.Parse(Console.ReadLine());

                if (repositorio.ReturnById(inputedID).Equals(null))
                {
                    Console.WriteLine();
                    Console.WriteLine("Série não encontrada!");
                    Console.WriteLine();
                    UpdateSerie();
                }

                ShowGenres();

                Console.Write("Digite o número do gênero da série: ");
                int inputedGenre = int.Parse(Console.ReadLine());

                if (GenreValidate(inputedGenre) == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("Gênero inexistente, tente novamente.");
                    Console.WriteLine();
                    UpdateSerie();
                }


                Console.Write("Escreva o título da série: ");
                string inputedTitle = Console.ReadLine();

                Console.Write("Escreva a descrição da série: ");
                string inputedDescription = Console.ReadLine();

                var updateSerie = new TvShow(inputedID, inputedTitle, (Genres)inputedGenre, inputedDescription);

                repositorio.Update(inputedID, updateSerie);

                Console.WriteLine();
                Console.WriteLine("Serie atualizada com sucesso!");
                Console.WriteLine();

            }
            catch (FormatException)
            {
                Console.WriteLine("Houve um erro de entrada! Lembre-se, somente números são permitidos.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Desculpe, ID não encontrado...");
            }
            finally
            {
                Manipulating();
            }

        }

        private static void DeleteTvShow()
        {
            try
            {
                Console.Write("Informe o ID da série para a exclusão: ");
                var inputedID = int.Parse(Console.ReadLine());
                repositorio.Delete(inputedID);
                Console.WriteLine();
                Console.WriteLine("Série removida!");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("ID não encontrado!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Houve um erro de entrada! Lembre-se, somente números são permitidos.");
            }
            finally
            {
                Manipulating();
            }
        }

        private static void GetTvShowById()
        {
            try
            {
                Console.Write("Informe o ID da série: ");
                var inputedID = int.Parse(Console.ReadLine());

                Console.WriteLine();

                var TvShowReturned = repositorio.ReturnById(inputedID);
                Console.WriteLine(TvShowReturned);

            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Série não encontrada!");
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("Houve um erro de entrada! Lembre-se, somente números são permitidos.");
            }
            finally
            {
                Manipulating();
            }
        }

        private static void InsertNewSerie()
        {
            try
            {
                ShowGenres();
                Console.Write("Digite o número do gênero da nova série: ");
                int inputedGenre = int.Parse(Console.ReadLine());


                if (GenreValidate(inputedGenre) == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("Gênero inexistente, tente novamente.");
                    Console.WriteLine();
                    InsertNewSerie();
                }


                Console.Write("Escreva o título da série: ");
                string inputedTitle = Console.ReadLine();

                Console.Write("Escreva a descrição da série: ");
                string inputedDescription = Console.ReadLine();

                var newTvSerie = new TvShow((int)repositorio.NextId(), inputedTitle, (Genres)inputedGenre, inputedDescription);

                repositorio.Insert(newTvSerie);

                Console.WriteLine("Serie inserida com sucesso!");

                Manipulating();
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("Houve um erro de entrada! Lembre-se, somente números são permitidos.");
                Console.WriteLine();
                InsertNewSerie();
            }


        }

        private static void ShowGenres()
        {
            var indice = 0;
            Console.WriteLine("Gêneros disponíveis: ");
            foreach (var genres in System.Enum.GetValues(typeof(Genres)))
            {
                Console.WriteLine($"{indice++} - {genres}");
            }

        }

        private static void ClearConsole()
        {
            Console.Clear();
        }

        private static void GetListTv()
        {
            var list = repositorio.GetList();

            if (list.Count == 0)
            {
                Console.WriteLine("Lista vazia...");
                return;
            }

            foreach (var serie in list)
            {
                Console.WriteLine(serie);
            }
        }

        private static bool GenreValidate(int inputedGenre)
        {
            var isValidate = System.Enum.IsDefined(genero.GetType(), inputedGenre);
            return isValidate;
        }

    }
}
