CREATE TABLE `osmanagerdb`.`servico_categoria_servico` (
  `servico_categoria_servico_id` INT NOT NULL AUTO_INCREMENT,
  `servico_id` INT NOT NULL,
  `categoria_servico_id` INT NOT NULL,
  PRIMARY KEY (`servico_categoria_servico_id`)
);
