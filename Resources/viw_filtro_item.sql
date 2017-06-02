create or replace view public.viw_filtro_item as
  select
    tbl_filtro_item.boo_and boo_filtro_item_and,
    tbl_filtro_item.dtt_alteracao dtt_filtro_item_alteracao,
    tbl_filtro_item.dtt_cadastro dtt_filtro_item_cadastro,
    tbl_filtro_item.int_filtro_id int_filtro_item_filtro_id,
    tbl_filtro_item.int_id int_filtro_item_id,
    tbl_filtro_item.int_operador int_filtro_item_operador,
    tbl_filtro_item.int_usuario_alteracao_id int_filtro_item_usuario_alteracao_id,
    tbl_filtro_item.int_usuario_cadastro_id int_filtro_item_usuario_cadastro_id,
    tbl_filtro_item.sql_coluna_nome sql_filtro_item_coluna_nome,
    
    tbl_filtro.sql_tabela_nome sql_filtro_tabela_nome,
    tbl_filtro.str_descricao str_filtro_descricao,
    tbl_filtro.str_nome str_filtro_nome

    -- tbl_usuario_alteracao.str_login str_usuario_alteracao_login,
    -- tbl_usuario_cadastro.str_login str_usuario_cadastro_login
  from
    tbl_filtro_item
    left join tbl_filtro on (tbl_filtro.int_id = tbl_filtro_item.int_filtro_id)
    --left join tbl_usuario tbl_usuario_alteracao on (tbl_usuario_alteracao.int_id = tbl_filtro_item.int_usuario_alteracao_id)
    --left join tbl_usuario tbl_usuario_cadastro on (tbl_usuario_cadastro.int_id = tbl_filtro_item.int_usuario_cadastro_id);