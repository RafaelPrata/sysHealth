////////////////StatusLeito/////////////////////////////////////
db.getCollection('StatusPedidoInternacao').insertMany([{'Descricao':'Aberto', 'Codigo':1},
                                                       {'Descricao':'Em atendimento', 'Codigo':2},
                                                       {'Descricao':'Concluído', 'Codigo':3},
                                            ]);
                                            
////////////////StatusLeito/////////////////////////////////////
db.getCollection('StatusLeito').insertMany([{'Descricao':'Ocupado', 'Codigo':1},
                                            {'Descricao':'Vago', 'Codigo':2},
                                            {'Descricao':'Reservado', 'Codigo':3},
                                            ]);
                        
////////////////TipoLeitos/////////////////////////////////////
db.getCollection('TipoLeito').insertMany([{'Descricao':'Leito Clínico', 'Codigo':1},
                        {'Descricao':'Leito Cirúrgico', 'Codigo':2},
                        {'Descricao':'Leito Obstétrico', 'Codigo':3},
                        {'Descricao':'Leito Pediátrico', 'Codigo':4},
                        {'Descricao':'Leito de Isolamento', 'Codigo':5},
                        {'Descricao':'Leito de Isolamento Reverso', 'Codigo':6},
                        {'Descricao':'Leito de Cuidados Intensivos (UTI)', 'Codigo':7},
                        {'Descricao':'Leito de Cuidados Intermediários (UCI)', 'Codigo':8},
                        {'Descricao':'Leito de Recuperação Pós-Anestésica (RPA)', 'Codigo':9},
                        {'Descricao':'Leito de Apoio para Procedimentos Diagnósticos e/ou Terapêuticos', 'Codigo':10},
                        {'Descricao':'Leito de Urgência e Emergência', 'Codigo':11},
                        {'Descricao':'Leito de Pré-Parto', 'Codigo':12}
                       ]);
////////////////TipoExames/////////////////////////////////////
db.getCollection('TipoExame').insertMany([{'Descricao':'Hemograma', 'Codigo':1},
                        {'Descricao':'Colesterol', 'Codigo':2},
                        {'Descricao':'Ureia e Creatinina', 'Codigo':3},
                        {'Descricao':'Papanicolau', 'Codigo':4},
                        {'Descricao':'Exames de urina', 'Codigo':5},
                        {'Descricao':'Exames de fezes', 'Codigo':6},
                        {'Descricao':'Glicemia', 'Codigo':7},
                        {'Descricao':'Transaminases (ALT e AST) ou TGP e TGO', 'Codigo':8},
                        {'Descricao':'TSH e T4 livre', 'Codigo':9},
                        {'Descricao':'Triglicerídeos', 'Codigo':10},
                        {'Descricao':'Ácido Úrico', 'Codigo':11},
                        {'Descricao':'Radiografia convencional (Raio-x)', 'Codigo':12},
                        {'Descricao':'Mamografia', 'Codigo':13},
                        {'Descricao':'Densitometria Óssea', 'Codigo':14},
                        {'Descricao':'Tomografia computadorizada', 'Codigo':15},
                        {'Descricao':'Ressonância magnética', 'Codigo':16},
                        {'Descricao':'Ultrassonografia', 'Codigo':17},
                        {'Descricao':'Medicina nuclear', 'Codigo':18},
                        {'Descricao':'Angiografia', 'Codigo':19}
                       ]);
////////////////ESPECIALIDADES/////////////////////////////////////
db.getCollection('Especialidade').insertMany([{'Descricao':'Acupuntura', 'Codigo':1},
                           {'Descricao':'Alergia e Imunologia', 'Codigo':2},
                           {'Descricao':'Anestesiologia', 'Codigo':3},
                           {'Descricao':'Angiologia e Cirurgia Vascular', 'Codigo':4},
                           {'Descricao':'Cardiologia', 'Codigo':5},
                           {'Descricao':'Cirurgia Cardiovascular', 'Codigo':6},
                           {'Descricao':'Cirurgia da Mao', 'Codigo':7},
                           {'Descricao':'Cirurgia de Cabeca e Pescoco', 'Codigo':8},
                           {'Descricao':'Cirurgia Geral', 'Codigo':9},
                           {'Descricao':'Cirurgia Pediatrica', 'Codigo':10},
                           {'Descricao':'Cirurgia Plastica', 'Codigo':11},
                           {'Descricao':'Cirurgia Toracica', 'Codigo':12},
                           {'Descricao':'Clinica Medica', 'Codigo':13},
                           {'Descricao':'Coloproctologia', 'Codigo':14},
                           {'Descricao':'Dermatologia', 'Codigo':15},
                           {'Descricao':'Dor', 'Codigo':16},
                           {'Descricao':'Endocrinologia e Metabologia', 'Codigo':17},
                           {'Descricao':'Endoscopia', 'Codigo':18},
                           {'Descricao':'Gastroenterologia', 'Codigo':19},
                           {'Descricao':'Genetica Medica', 'Codigo':20},
                           {'Descricao':'Geriatria', 'Codigo':21},
                           {'Descricao':'Ginecologia e Obstetricia', 'Codigo':22},
                           {'Descricao':'Hematologia e Hemoterapia', 'Codigo':23},
                           {'Descricao':'Homeopatia', 'Codigo':24},
                           {'Descricao':'Infectologia', 'Codigo':25},
                           {'Descricao':'Mastologia', 'Codigo':26},
                           {'Descricao':'Nefrologia', 'Codigo':27},
                           {'Descricao':'Neurologia', 'Codigo':28},
                           {'Descricao':'Nutrologia', 'Codigo':29},
                           {'Descricao':'Oftalmologia', 'Codigo':30},
                           {'Descricao':'Ortopedia e Traumatologia', 'Codigo':31},
                           {'Descricao':'Otorrinolaringologia', 'Codigo':32},
                           {'Descricao':'Patologia', 'Codigo':33},
                           {'Descricao':'Pediatria', 'Codigo':34},
                           {'Descricao':'Pneumologia', 'Codigo':35},
                           {'Descricao':'Reumatologia', 'Codigo':36},
                           {'Descricao':'Sexologia', 'Codigo':37},
                           {'Descricao':'Urologia', 'Codigo':38}                           
                          ]);
                           
////////////////PERFIS/////////////////////////////////////
db.getCollection('Perfil').insertMany([{'Descricao':'Administrador', 'Codigo' :1},
{'Descricao':'Atendente', 'Codigo' :2},
{'Descricao':'UsuarioSUS', 'Codigo' :3}]);

////////////////HORARIOS/////////////////////////////////////

var horarios = db.getCollection('Horario');
var horaInicial = '08:00'
var i = 1;

while(Number(horaInicial.split(':')[0]) < 20){
     
    var intHoraInicial = Number(horaInicial.split(':')[0]);
    var intMinutoInicial = Number(horaInicial.split(':')[1]);
        
    var horaFinal =  (intMinutoInicial > 0 ? (intHoraInicial+1).toString() : intHoraInicial.toString()) + ':' + 
                     (intMinutoInicial > 0 ? '00' : '30');
           
    horarios.insert({
                        'Codigo': i,
                        'HoraInicial': "'" + horaInicial + "'", 
                        'HoraFinal': "'" + horaFinal + "'"
                    });  
   
    i++;
    horaInicial = horaFinal;                 
}



////////////////Medicos/////////////////////////////////////
var medicos = db.getCollection('Medico');

var especialidades = db.getCollection('Especialidade').find();

var codigoMedico = 1;



especialidades.forEach(function(esp){

    

    for(i=1;i<=3;i++){

        medicos.insert({'Codigo': codigoMedico,

                        'Nome': 'Médico ' + codigoMedico,

                        'CRM': 'CRM' + codigoMedico,

                        'CodigoEspecialidade': esp.Codigo}

                      );

                        

        codigoMedico++;

    }       

});


