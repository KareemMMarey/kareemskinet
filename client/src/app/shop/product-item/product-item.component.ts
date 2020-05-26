import { Component, OnInit, Input } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss']
})
export class ProductItemComponent implements OnInit {
  /* the following line is to recieve prameter from parent product */
@Input() product: IProduct;
  constructor() { }

  ngOnInit(): void {
  }

}
