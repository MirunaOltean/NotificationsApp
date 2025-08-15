import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'byAuthor'
})
export class ByAuthorPipe implements PipeTransform {

  transform(value: string, author: string): string {
    return author + value;
  }

}
