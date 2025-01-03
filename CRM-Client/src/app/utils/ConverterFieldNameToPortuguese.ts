export class ConverterFieldName {
     static fields: string[] = [
          'name', 'dateOfBirth', 'address', 'registerValue', 'paymentDay',
          'emergencePhone', 'allergies', 'phone', 'type', 'times', 'dosage',
          'observation', 'serie', 'email', 'cpf'
     ];

     static fieldMap: { [key: string]: string } = {
          'name': 'nome',
          'dateOfBirth': 'data de aniversário',
          'address': 'endereço',
          'registerValue': 'valor de registro',
          'paymentDay': 'dia de pagamento',
          'emergencePhone': 'telefone de emergência',
          'allergies': 'alergias',
          'phone': 'telefone',
          'type': 'tipo',
          'times': 'horários',
          'dosage': 'dosagem',
          'observation': 'observação',
          'serie': 'serie',
          'email': 'email',
          'cpf': 'cpf'
     }

     static verify(fieldName: string): string {
          console.log(fieldName)
          if (this.fields.includes(fieldName)) {
               return this.converter(fieldName);
          }

          return 'ocorreu um erro';
     }

     static converter(field: string): string {
          if (field in this.fieldMap) {
               return this.fieldMap[field];
          }

          return 'ocorreu um erro';
     }
}