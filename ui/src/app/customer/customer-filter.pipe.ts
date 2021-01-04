import { Pipe, PipeTransform } from '@angular/core';
import { Customer } from './customer';

@Pipe({
  name: 'customerFilter'
})
export class CustomerFilterPipe implements PipeTransform {

  transform(value: Customer[], filterText?: string): Customer[] {

    filterText = filterText ? filterText.toLocaleLowerCase() : null

    return filterText ? value.filter((c: Customer) => c.bayiAd
      .toLocaleLowerCase().indexOf(filterText) !== -1) : value;
  }

}
