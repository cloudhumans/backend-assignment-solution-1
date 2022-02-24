# Improvements/featuers Backlog

### 0. Bugfix
Descomentar os 2 testes que estão com annotation [Ignore] e corrigi-los.

### 1. Score v2
Nós não consideramos mais a experiência de vendas ("sales") como algo muito valoroso. Entretanto, qualquer experiência relacionada a boa escrita deve ser considerada, já que nossos atendimentos de suporte são feitos via chat. Portanto queremos remover a opção `"sales"` e no lugar dela colocar `"professional_writing_experience"`, que ao invés de 5 vai valer 6 pontos.

### 2. Score v3
Experiência de "bachelors_degree_or_high" agora vale 3 pontos. Além disso, caso a pessoa não tenha nenhum nível de escolaridade queremos remover 1 ponto do seu score (nesse caso o json de entrada vai receber uma string `"no_education"`).

### 3. Adicionar novo projeto
The project "Attend to users support for a XPTO Company" requires Pros with score greater than 4

### 4. Inelegível se score de escrita for baixo
A partir de agora, se o writing score for abaixo de 0.3, ao invés de remover 1 ponto de seu score vamos torná-lo inelegível em todos os projetos.
