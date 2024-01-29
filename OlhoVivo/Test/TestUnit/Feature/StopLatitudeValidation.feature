Feature: Validar Limites de Latitude

  Como um usuário do aplicativo de mapeamento
  Eu quero garantir que a latitude inserida seja válida
  Para evitar erros de localização e navegação

  Scenario: Validar Latitude Inferior
    Given que estou inserindo uma latitude menor que -90
    When tento salvar a latitude com valor inferior ao permitido
    Then devo receber uma mensagem de erro indicando que a latitude inferior é inválida

  Scenario: Validar Latitude Superior
    Given que estou inserindo uma latitude maior que 90
    When tento salvar a latitude com valor superior ao permitido
    Then devo receber uma mensagem de erro indicando que a latitude superior é inválida