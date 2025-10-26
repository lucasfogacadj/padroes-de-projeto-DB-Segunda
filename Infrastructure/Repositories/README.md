# Grupo Repository

Objetivo: Implementar o Repository Pattern para a entidade `Produto`.

## Tarefas
1. Criar a classe `ProdutoRepository` que implementa `IProdutoRepository`.
2. Usar `AppDbContext` via injeção de dependência.
3. Métodos mínimos:
   - `GetAllAsync` (usar `AsNoTracking()`)
   - `GetByIdAsync`
   - `AddAsync`
   - `RemoveAsync`
   - `SaveChangesAsync`
4. Não adicionar regras de negócio aqui (apenas persistência). Regras ficam no Service / Factory.
5. Justificar no final do arquivo (seção) quando seria aceitável NÃO usar repository (ex: projeto pequeno, EF Core já abstrai bastante).

## Dicas
- Use `FindAsync` para busca por id.
- Não exponha o `DbContext` para fora.
- Evite retornar `IQueryable` para não vazar a infraestrutura.

## Entrega
- Criar branch: `feature/repository`.
- Adicionar testes (opcional + bônus) usando `UseInMemoryDatabase`.
- Atualizar `Program.cs` registrando: `builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();`.

## Explicações:

## -por que em APIs simples minimalistas pode ser overengineering
   Overengineering é quando é feita complexa e extensa demais para algo que poderia ter sido feito de forma mais simples. Contrariando o uso de uma API minimalista. Isso pode acontecer quando são adicionadas camadas, padrões ou abstrações desnecessárias para projetos mais simples que não precisam disso.


## -Quando NÃO usar repository pattern
   Em projetos pequenos ou APIs minimalistas, onde tem pouca consulta e poucas coisas para guardar.
   O DbContext do EF core ja consegue fazer tudo sozinho, então criar  o Repository seria só trabalho extra.
   Em sistemas maiores, com muitas regras de negócio e multiplos lugares para salvar dados, ai sim vale muito apena.

   VANTAGENS DO REPOSITORY:
   Matem o codigo organizado, organiza em camadas
   O  service não precisa se preocupar com detalhes do banco de dados
   Facilita testes e mudanças futuras no banco de dados sem bagunçar a aplicação

   DESVANTAGENS:
   Para APIs simples,  pode acabar gerando codigo extra e desnecessário
   O DbContext ja tem metodos parecidos, então as vezes é so um extra que não é estritamente necessário

   OBSERVAÇÃO:
   Aqui dentro do Repository só mexemos com dados, criar, ler, remover e salvar
   As regras de negocio devem ficar em camadas diferentes, como Service e Factory

