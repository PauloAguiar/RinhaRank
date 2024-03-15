# Rank da Rinha

Metodologia

O script [Program.cs](LogParser/Program.cs) foi utilizado para extrair todos os elapsed times de requests do arquivo Simulation.log, resultando em um arquivo por submissao como abaixo:
```
Folder,Type,StartTime,EndTime,ElapsedTime,Result
"phaguiar-net","validações","1710105131480","1710105131517","37","OK"
"phaguiar-net","validações","1710105131482","1710105131493","11","OK"
"phaguiar-net","validações","1710105131494","1710105131523","29","OK"
"phaguiar-net","validações","1710105131483","1710105131493","10","OK"
"phaguiar-net","validações","1710105131479","1710105131508","29","OK"
```

O ChatGPT foi utilizado para gerar tags baseadas nas README de cada repositorio.
Esses arquivos foram ingeridos em no Azure Data Explorer e ordernados atraves da query nesse arquivo: [Query](query.kql)

Os resultado final da query pode ser visto aqui:

[Resultado - Sem Validações](result-sem-validacoes.csv)

[Resultado - Somente Validações](result-so-validacoes.csv)

[Resultado - Tudo](result-total.csv)

TOP 20 (Sem Validações)
| Rank | AvgTotal | Folder                                       | AvgCredito | AvgDebito | AvgExtrato | SuccessCount | ErrorCount |
|------|----------|----------------------------------------------|------------|-----------|------------|--------------|------------|
| 1    | 0.222206 | [asfernandes-cpp-haproxy-mongoose-lmdb](https://github.com/zanfranceschi/rinha-de-backend-2024-q1/tree/main/participantes/asfernandes-cpp-haproxy-mongoose-lmdb)       | 0.252971   | 0.201563  | 0.333871   | 61380        | 0          |
| 2    | 0.311404 | [felipemarkson-rust](https://github.com/zanfranceschi/rinha-de-backend-2024-q1/tree/main/participantes/felipemarkson-rust)                          | 0.372457   | 0.272844  | 0.48172    | 61380        | 0          |
| 3    | 0.35189  | [rodolphovs](https://github.com/zanfranceschi/rinha-de-backend-2024-q1/tree/main/participantes/rodolphovs)                                  | 0.327744   | 0.361296  | 0.40914    | 61380        | 0          |
| 4    | 0.367807 | [maxwell-fs](https://github.com/zanfranceschi/rinha-de-backend-2024-q1/tree/main/participantes/maxwell-fs)                                  | 0.384542   | 0.35648   | 0.430645   | 61380        | 0          |
| 5    | 0.367856 | [vifonsec4-lb-khd0](https://github.com/zanfranceschi/rinha-de-backend-2024-q1/tree/main/participantes/vifonsec4-lb-khd0)                           | 0.364854   | 0.371457  | 0.323118   | 61380        | 0          |
| 6    | 0.372401 | [lpicanco-moonshine](https://github.com/zanfranceschi/rinha-de-backend-2024-q1/tree/main/participantes/lpicanco-moonshine)                          | 0.349899   | 0.380484  | 0.440323   | 61380        | 0          |
| 7    | 0.3819   | [galodoido](https://github.com/zanfranceschi/rinha-de-backend-2024-q1/tree/main/participantes/galodoido)                                   | 0.396375   | 0.369642  | 0.48871    | 61380        | 0          |
| 8    | 0.393027 | [rodolphovs-c-db](https://github.com/zanfranceschi/rinha-de-backend-2024-q1/tree/main/participantes/rodolphovs-c-db)                             | 0.396928   | 0.388553  | 0.446774   | 61380        | 0          |
| 9    | 0.397361 | [tomer](https://github.com/zanfranceschi/rinha-de-backend-2024-q1/tree/main/participantes/tomer)                                       | 0.384542   | 0.403026  | 0.413441   | 61380        | 0          |
| 10   | 0.406419 | [arthur-rust-go-c](https://github.com/zanfranceschi/rinha-de-backend-2024-q1/tree/main/participantes/arthur-rust-go-c)                            | 0.385549   | 0.413565  | 0.476882   | 61380        | 0          |
| 11   | 0.427208 | [andretpc](https://github.com/zanfranceschi/rinha-de-backend-2024-q1/tree/main/participantes/andretpc)                                    | 0.451208   | 0.411447  | 0.506989   | 61380        | 0          |
| 12   | 0.428935 | [navarro](https://github.com/zanfranceschi/rinha-de-backend-2024-q1/tree/main/participantes/navarro)                                     | 0.440332   | 0.421508  | 0.465591   | 61380        | 0          |
| 13   | 0.440925 | [levifonseca](https://github.com/zanfranceschi/rinha-de-backend-2024-q1/tree/main/participantes/levifonseca)                                 | 0.479053   | 0.415734  | 0.570968   | 61380        | 0          |
| 14   | 0.451336 | [vifonsec4-nginx](https://github.com/zanfranceschi/rinha-de-backend-2024-q1/tree/main/participantes/vifonsec4-nginx)                             | 0.473464   | 0.442234  | 0.40914    | 61380        | 0          |
| 15   | 0.451466 | [joao-peterson](https://github.com/zanfranceschi/rinha-de-backend-2024-q1/tree/main/participantes/joao-peterson)                               | 0.527644   | 0.396167  | 0.817204   | 61380        | 0          |
| 16   | 0.461339 | [navarro-espora-embedded](https://github.com/zanfranceschi/rinha-de-backend-2024-q1/tree/main/participantes/navarro-espora-embedded)                     | 0.444209   | 0.470449  | 0.45       | 61380        | 0          |
| 17   | 0.464989 | [renatolfc-🦀](https://github.com/zanfranceschi/rinha-de-backend-2024-q1/tree/main/participantes/renatolfc-🦀)                                | 0.443656   | 0.464145  | 0.710753   | 61380        | 0          |
| 18   | 0.469143 | [rafaelrcamargo](https://github.com/zanfranceschi/rinha-de-backend-2024-q1/tree/main/participantes/rafaelrcamargo)                              | 0.486405   | 0.456909  | 0.545699   | 61380        | 0          |
| 19   | 0.470674 | [asfernandes-cpp-haproxy-mongoose-pgsql](https://github.com/zanfranceschi/rinha-de-backend-2024-q1/tree/main/participantes/asfernandes-cpp-haproxy-mongoose-pgsql)      | 0.458359   | 0.470953  | 0.596237   | 61380        | 0          |
| 20   | 0.48361  | [thusspokebieu-activej](https://github.com/zanfranceschi/rinha-de-backend-2024-q1/tree/main/participantes/thusspokebieu-activej)                       | 0.491944   | 0.473197  | 0.616667   | 61380        | 0          |
