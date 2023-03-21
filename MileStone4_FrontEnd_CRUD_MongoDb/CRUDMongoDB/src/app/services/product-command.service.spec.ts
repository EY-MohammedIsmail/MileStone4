import { TestBed } from '@angular/core/testing';

import { ProductCommandService } from './product-command.service';

describe('ProductCommandService', () => {
  let service: ProductCommandService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProductCommandService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
