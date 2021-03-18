import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QuestionsItemsComponent } from './questions-items.component';

describe('QuestionsItemsComponent', () => {
  let component: QuestionsItemsComponent;
  let fixture: ComponentFixture<QuestionsItemsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QuestionsItemsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QuestionsItemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
