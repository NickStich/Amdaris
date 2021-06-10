import { DatePipe } from '@angular/common';
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'dateFormat'
})
export class DateFormatPipe implements PipeTransform {

  transform(date: Date | string, format: string = 'yyyy-MM-dd'): string {
    date = new Date(date);  // if orginal type was a string
    date.setDate(date.getDate());
    return new DatePipe('en-US').transform(date, format);
  }

}
