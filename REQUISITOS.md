# Requisitos CACS

## Funcionais

- RF01: O sistema deve permitir que o usuário faça login utilizando nome de usuário e senha válidos.
- RF02: O sistema deve permitir que o usuário visualize seu limite de categoria total.
- RF03: O sistema deve permitir que o usuário visualize seu limite de categoria disponível.
- RF04: O sistema deve permitir que o usuário visualize o limite de categoria total do grupo.
- RF05: O sistema deve permitir que o usuário visualize o limite de categoria disponível do grupo.
- RF06: O sistema deve permitir que o usuário aumente sua quantidade de categoria, desde que o novo valor não ultrapasse seu limite individual.
- RF07: O sistema deve permitir que o usuário reduza sua quantidade de categoria.
- RF08: O sistema deve atualizar os limites individuais e do grupo após alterações de categoria.
- RF09: O sistema deve impedir que alterações simultâneas resultem em um limite de categoria inválido.
- RF10: O sistema deve refletir alterações realizadas por outros usuários conectados.

## Não Funcionais

- RNF01: O serviço deve estar disponível 24 horas por dia, 7 dias por semana, exceto durante manutenções programadas.
- RNF02: O sistema deve responder às requisições de usuário em no máximo 2 segundos em condições normais de operação.
- RNF03: O serviço deve ser acessível por meio de um link utilizando um navegador web.
- RNF04: O serviço deve permitir acesso somente aos 7 usuários previamente autorizados.
- RNF05: O serviço deve suportar até 7 usuários simultâneos.
- RNF06: O sistema deve suportar operações concorrentes de leitura e escrita sem permitir condições de corrida que resultem em perda ou inconsistência de dados.
- RNF07: O serviço deve funcionar em computadores, tablets e dispositivos móveis.

## Regras de Negócio

- RN01: Cada usuário possui um limite inicial de 16 pontos de categoria.
- RN02: O limite de categoria disponível de um usuário corresponde ao seu limite total menos os pontos atualmente utilizados.
- RN03: O limite total do grupo corresponde à soma dos limites totais dos usuários participantes.
- RN04: O limite disponível do grupo corresponde à soma dos limites disponíveis dos usuários participantes.
- RN05: O sistema não deve permitir que um usuário ultrapasse seu limite individual.
- RN06: Uma operação concorrente não deve permitir que o limite disponível fique negativo ou que o limite utilizado ultrapasse o limite total.
