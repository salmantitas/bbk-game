/**
 * @version 1.0.0.0
 * @copyright Copyright ©  2020
 * @compiler Bridge.NET 17.10.1
 */
Bridge.assembly("MatchingGameBridge", function ($asm, globals) {
    "use strict";

    Bridge.define("BC_Functions.Position2D", {
        statics: {
            methods: {
                op_Addition: function (a, b) {
                    return new BC_Functions.Position2D.$ctor3(((a.x + b.x) | 0), ((a.y + b.y) | 0));
                },
                op_Subtraction: function (a, b) {
                    return new BC_Functions.Position2D.$ctor3(((a.x - b.x) | 0), ((a.y - b.y) | 0));
                },
                op_Multiply: function (pos, value) {
                    return new BC_Functions.Position2D.$ctor3(Bridge.Int.mul(pos.x, value), Bridge.Int.mul(pos.y, value));
                }
            }
        },
        fields: {
            x: 0,
            y: 0
        },
        props: {
            X: {
                get: function () {
                    return this.x;
                },
                set: function (value) {
                    this.x = value;
                }
            },
            Y: {
                get: function () {
                    return this.y;
                },
                set: function (value) {
                    this.y = value;
                }
            },
            Area: {
                get: function () {
                    return Bridge.Int.mul(this.x, this.y);
                }
            }
        },
        ctors: {
            ctor: function () {
                this.$initialize();
                this.x = 0;
                this.x = 0;
            },
            $ctor2: function (position) {
                this.$initialize();
                this.x = position;
                this.y = position;
            },
            $ctor3: function (x, y) {
                this.$initialize();
                this.x = x;
                this.y = y;
            },
            $ctor1: function (position) {
                this.$initialize();
                this.x = position.x;
                this.y = position.y;
            }
        },
        methods: {
            SetPosition$2: function (x, y) {
                this.x = x;
                this.y = y;
            },
            SetPosition$1: function (position) {
                this.x = position;
                this.y = position;
            },
            SetPosition: function (position) {
                this.SetPosition$2(position.X, position.Y);
            },
            toString: function () {
                return "(" + (Bridge.toString(this.X) || "") + "," + (Bridge.toString(this.Y) || "") + ")";
            }
        }
    });

    Bridge.define("MatchingGameBridge.App", {
        main: function Main () {
            System.Console.WriteLine("Welcome to Bridge.NET");
            var card = new MatchingGameFrameworks.Card.$ctor1(0, "image.gif");
            System.Console.WriteLine(card);



        }
    });

    Bridge.define("MatchingGameFrameworks.Card", {
        fields: {
            id: 0,
            imageLocation: null,
            flipped: false,
            removed: false
        },
        props: {
            /**
             * ID
             *
             * @instance
             * @public
             * @memberof MatchingGameFrameworks.Card
             * @function ID
             * @type number
             */
            ID: {
                get: function () {
                    return this.id;
                },
                set: function (value) {
                    this.id = value;
                }
            },
            /**
             * Image Location
             *
             * @instance
             * @public
             * @memberof MatchingGameFrameworks.Card
             * @function ImageLocation
             * @type string
             */
            ImageLocation: {
                get: function () {
                    return this.imageLocation;
                },
                set: function (value) {
                    this.imageLocation = value;
                }
            },
            /**
             * card is fliped or not
             *
             * @instance
             * @public
             * @memberof MatchingGameFrameworks.Card
             * @function Flipped
             * @type boolean
             */
            Flipped: {
                get: function () {
                    if (this.removed) {
                        return false;
                    }
                    return this.flipped;
                },
                set: function (value) {
                    this.flipped = value;
                }
            },
            /**
             * card is removed
             *
             * @instance
             * @public
             * @memberof MatchingGameFrameworks.Card
             * @function Removed
             * @type boolean
             */
            Removed: {
                get: function () {
                    if (Bridge.referenceEquals(this.imageLocation, "N/A")) {
                        return true;
                    }
                    return this.removed;
                },
                set: function (value) {
                    this.removed = value;
                }
            }
        },
        ctors: {
            ctor: function () {
                this.$initialize();
                this.flipped = false;
                this.removed = false;
            },
            $ctor1: function (id, imageLocation) {
                this.$initialize();
                this.id = id;
                this.imageLocation = imageLocation;
                this.flipped = false;
                this.removed = false;
            }
        },
        methods: {
            IsMatch: function (otherCard, throwCompareToSelfException) {
                if (throwCompareToSelfException === void 0) { throwCompareToSelfException = true; }
                if (Bridge.referenceEquals(otherCard, this)) {
                    return false;
                }

                if (this.ID === otherCard.ID) {
                    return true;
                } else {
                    return false;
                }
            },
            Flip: function () {
                this.flipped = !this.flipped;
            },
            Remove: function () {
                this.removed = true;
            },
            Reset: function () {
                this.flipped = false;
                this.removed = false;
            }
        }
    });

    Bridge.define("MatchingGameFrameworks.Game", {
        statics: {
            fields: {
                MINIMUM_CARD_IN_A_ROW: 0
            },
            ctors: {
                init: function () {
                    this.MINIMUM_CARD_IN_A_ROW = 2;
                }
            }
        },
        fields: {
            cards: null,
            cardSize: null,
            backOfCardImageLocation: null,
            test: 0
        },
        props: {
            Cards: {
                get: function () {
                    return Bridge.cast(System.Array.clone(this.cards), System.Array.type(MatchingGameFrameworks.Card, 2));
                }
            },
            CardSize: {
                get: function () {
                    return new BC_Functions.Position2D.$ctor1(this.cardSize);
                },
                set: function (value) {
                    var $t;
                    this.cardSize = new BC_Functions.Position2D.$ctor1(value);

                    if (this.cardSize.X < MatchingGameFrameworks.Game.MINIMUM_CARD_IN_A_ROW) {
                        throw new System.Exception("Below minimum size");
                    }

                    if (this.cardSize.Y < MatchingGameFrameworks.Game.MINIMUM_CARD_IN_A_ROW) {
                        throw new System.Exception("Below minimum size");
                    }

                    if (this.TotalCardCount % 2 === 1) {
                        throw new System.Exception("Odd number of cards");
                    }

                    this.cards = System.Array.create(null, null, MatchingGameFrameworks.Card, this.cardSize.X, this.cardSize.Y);
                    for (var x = 0; x < this.cardSize.X; x = (x + 1) | 0) {
                        for (var y = 0; y < this.cardSize.Y; y = (y + 1) | 0) {
                            this.cards.set([x, y], new MatchingGameFrameworks.Card.ctor());
                            this.cards.get([x, y]).ID = (x + (Bridge.Int.mul(y, this.cardSize.X))) | 0;
                            if (this.cards.get([x, y]).ID >= this.UniqueCardCount) {
                                ($t = this.cards.get([x, y])).ID = ($t.ID - this.UniqueCardCount) | 0;
                            }
                        }
                    }
                }
            },
            BackOfCardImageLocation: {
                get: function () {
                    return this.backOfCardImageLocation;
                },
                set: function (value) {
                    this.backOfCardImageLocation = value;
                }
            },
            TotalCardCount: {
                get: function () {
                    return this.cardSize.Area;
                }
            },
            UniqueCardCount: {
                get: function () {
                    return ((Bridge.Int.div(this.cardSize.Area, 2)) | 0);
                }
            },
            FlipedCardsCount: {
                get: function () {
                    var flipCardsCount = 0;
                    for (var x = 0; x < this.cardSize.X; x = (x + 1) | 0) {
                        for (var y = 0; y < this.cardSize.Y; y = (y + 1) | 0) {
                            if (this.cards.get([x, y]).Flipped) {
                                flipCardsCount = (flipCardsCount + 1) | 0;
                            }
                        }
                    }
                    return flipCardsCount;
                }
            },
            Test: {
                get: function () {
                    return this.test;
                },
                set: function (value) {
                    this.test = value;
                }
            },
            RemovedCardsCount: {
                get: function () {
                    var removedCardsCount = 0;
                    for (var x = 0; x < this.cardSize.X; x = (x + 1) | 0) {
                        for (var y = 0; y < this.cardSize.Y; y = (y + 1) | 0) {
                            if (this.cards.get([x, y]).Removed) {
                                removedCardsCount = (removedCardsCount + 1) | 0;
                            }
                        }
                    }
                    return removedCardsCount;
                }
            },
            FlipedCardsMatch: {
                get: function () {
                    if (this.FlipedCardsCount !== 2) {
                        return false;
                    }
                    var card1 = null;
                    var card2 = null;
                    for (var x = 0; x < this.cardSize.X; x = (x + 1) | 0) {
                        for (var y = 0; y < this.cardSize.Y; y = (y + 1) | 0) {
                            if (this.cards.get([x, y]).Flipped) {
                                if (card1 == null) {
                                    card1 = this.cards.get([x, y]);
                                } else {
                                    card2 = this.cards.get([x, y]);
                                }
                            }
                        }
                    }
                    return card1.IsMatch(card2);
                }
            },
            GameComplete: {
                get: function () {
                    return this.HiddenCardCount === 0;
                }
            },
            CardsRemain: {
                get: function () {
                    var cardsRemain = 0;
                    for (var x = 0; x < this.cardSize.X; x = (x + 1) | 0) {
                        for (var y = 0; y < this.cardSize.Y; y = (y + 1) | 0) {
                            if (!this.cards.get([x, y]).Removed) {
                                cardsRemain = (cardsRemain + 1) | 0;
                            }
                        }
                    }

                    return cardsRemain;
                }
            },
            HiddenCardCount: {
                get: function () {
                    var hiddenCardsCount = 0;
                    for (var x = 0; x < this.cardSize.X; x = (x + 1) | 0) {
                        for (var y = 0; y < this.cardSize.Y; y = (y + 1) | 0) {
                            if (!(this.cards.get([x, y]).Flipped || this.cards.get([x, y]).Removed)) {
                                hiddenCardsCount = (hiddenCardsCount + 1) | 0;
                            }
                        }
                    }
                    return hiddenCardsCount;
                }
            }
        },
        ctors: {
            ctor: function (columnsCount, rowCount) {
                this.$initialize();
                this.CardSize = new BC_Functions.Position2D.$ctor3(columnsCount, rowCount);
            }
        },
        methods: {
            ResetGame: function () {
                for (var x = 0; x < this.cardSize.X; x = (x + 1) | 0) {
                    for (var y = 0; y < this.cardSize.Y; y = (y + 1) | 0) {
                        this.cards.get([x, y]).Reset();
                    }
                }
            },
            SwitchSpots: function (card1, card2, throwCompareToSelfException) {
                if (throwCompareToSelfException === void 0) { throwCompareToSelfException = true; }
                if (!Bridge.referenceEquals(card1.v, card2.v)) {
                    var temp = card1.v;
                    card1.v = card2.v;
                    card2.v = temp;
                }
            },
            Shuffle: function (numberOfShuffles) {
                if (numberOfShuffles === void 0) { numberOfShuffles = 1; }
                if (numberOfShuffles < 1) {
                    throw new System.Exception("Below Minimum");
                }

                var random = new System.Random.ctor();
                for (var z = 0; z < numberOfShuffles; z = (z + 1) | 0) {
                    for (var x = 0; x < this.cardSize.X; x = (x + 1) | 0) {
                        for (var y = 0; y < this.cardSize.Y; y = (y + 1) | 0) {
                            var X = random.Next$1(this.cardSize.X);
                            var Y = random.Next$1(this.cardSize.Y);
                            this.SwitchSpots(Bridge.ref(this.cards, [x, y]), Bridge.ref(this.cards, [X, Y]), false);
                        }
                    }
                }
            },
            GetImage: function (column, row) {
                if (this.cards.get([column, row]).Flipped) {
                    return this.cards.get([column, row]).ImageLocation;
                } else {
                    return this.backOfCardImageLocation;
                }
            },
            HideAllCards: function () {
                for (var x = 0; x < this.cardSize.X; x = (x + 1) | 0) {
                    for (var y = 0; y < this.cardSize.Y; y = (y + 1) | 0) {
                        this.cards.get([x, y]).Flipped = false;
                    }
                }
            },
            RemoveFlipedCards: function () {
                for (var x = 0; x < this.cardSize.X; x = (x + 1) | 0) {
                    for (var y = 0; y < this.cardSize.Y; y = (y + 1) | 0) {
                        if (this.cards.get([x, y]).Flipped) {
                            this.cards.get([x, y]).Removed = true;
                            ;
                        }
                    }
                }
            }
        }
    });
});

//# sourceMappingURL=data:application/json;base64,ewogICJ2ZXJzaW9uIjogMywKICAiZmlsZSI6ICJNYXRjaGluZ0dhbWVCcmlkZ2UuanMiLAogICJzb3VyY2VSb290IjogIiIsCiAgInNvdXJjZXMiOiBbIkFwcC5jcyJdLAogICJuYW1lcyI6IFsiIl0sCiAgIm1hcHBpbmdzIjogIjs7Ozs7Ozs7Ozs7dUNBZ2hCc0NBLEdBQWNBO29CQUVqREEsT0FBT0EsSUFBSUEsK0JBQVdBLFFBQU1BLFdBQUtBLFFBQU1BOzswQ0FHSkEsR0FBY0E7b0JBRWpEQSxPQUFPQSxJQUFJQSwrQkFBV0EsUUFBTUEsV0FBS0EsUUFBTUE7O3VDQUdKQSxLQUFnQkE7b0JBRW5EQSxPQUFPQSxJQUFJQSwrQkFBV0Esc0JBQVFBLFFBQU9BLHNCQUFRQTs7Ozs7Ozs7Ozs7b0JBOUV2Q0EsT0FBT0E7OztvQkFDUEEsU0FBSUE7Ozs7O29CQU1KQSxPQUFPQTs7O29CQUNQQSxTQUFJQTs7Ozs7b0JBc0RUQSxPQUFPQSx1QkFBSUE7Ozs7Ozs7Z0JBakRaQTtnQkFDQUE7OzhCQUlDQTs7Z0JBRURBLFNBQUlBO2dCQUNKQSxTQUFJQTs7OEJBR0hBLEdBQ0RBOztnQkFFQUEsU0FBU0E7Z0JBQ1RBLFNBQVNBOzs4QkFFUUE7O2dCQUVqQkEsU0FBU0E7Z0JBQ1RBLFNBQVNBOzs7O3FDQUdzQkEsR0FBT0E7Z0JBRXRDQSxTQUFTQTtnQkFDVEEsU0FBU0E7O3FDQVFzQkE7Z0JBRS9CQSxTQUFJQTtnQkFDSkEsU0FBSUE7O21DQUcyQkE7Z0JBRS9CQSxtQkFBWUEsWUFBWUE7OztnQkFYeEJBLE9BQU9BLE9BQU1BLHdDQUFxQkE7Ozs7Ozs7WUE3ZWxDQTtZQUNBQSxXQUFZQSxJQUFJQTtZQUNoQkEseUJBQWtCQTs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7b0JBMEJaQSxPQUFPQTs7O29CQUNQQSxVQUFLQTs7Ozs7Ozs7Ozs7Ozs7b0JBU0xBLE9BQU9BOzs7b0JBQ1BBLHFCQUFnQkE7Ozs7Ozs7Ozs7Ozs7O29CQVdyQkEsSUFBSUE7d0JBRUhBOztvQkFFREEsT0FBT0E7OztvQkFFRkEsZUFBVUE7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QkEsT0FBZ0JBOztnQkFFdkRBLElBQUlBLGlDQUFTQTtvQkFFWkEsV0FBWUE7b0JBQ1pBLFVBQVFBO29CQUNSQSxVQUFRQTs7OytCQUlVQTs7Z0JBRW5CQSxJQUFJQTtvQkFFSEEsTUFBTUEsSUFBSUE7OztnQkFHWEEsYUFBZ0JBLElBQUlBO2dCQUNwQkEsS0FBS0EsV0FBV0EsSUFBSUEsa0JBQWtCQTtvQkFFckNBLEtBQUtBLFdBQVdBLElBQUlBLGlCQUFZQTt3QkFFL0JBLEtBQUtBLFdBQVdBLElBQUlBLGlCQUFZQTs0QkFFL0JBLFFBQVFBLGNBQVlBOzRCQUNwQkEsUUFBUUEsY0FBWUE7NEJBQ3BCQSw0QkFBZ0JBLGFBQU1BLEdBQUdBLGdCQUFRQSxhQUFNQSxHQUFHQTs7Ozs7Z0NBeUJ2QkEsUUFBWUE7Z0JBRWxDQSxJQUFJQSxnQkFBTUEsUUFBUUE7b0JBRWpCQSxPQUFPQSxnQkFBTUEsUUFBUUE7O29CQUlyQkEsT0FBT0E7Ozs7Z0JBTVJBLEtBQUtBLFdBQVdBLElBQUlBLGlCQUFZQTtvQkFFL0JBLEtBQUtBLFdBQVdBLElBQUlBLGlCQUFZQTt3QkFFL0JBLGdCQUFNQSxHQUFHQTs7Ozs7Z0JBc0ZYQSxLQUFLQSxXQUFXQSxJQUFJQSxpQkFBWUE7b0JBRS9CQSxLQUFLQSxXQUFXQSxJQUFJQSxpQkFBWUE7d0JBRS9CQSxJQUFJQSxnQkFBTUEsR0FBR0E7NEJBRVpBLGdCQUFNQSxHQUFHQTs0QkFBbUJBIiwKICAic291cmNlc0NvbnRlbnQiOiBbInVzaW5nIEJDX0Z1bmN0aW9ucztcclxudXNpbmcgQnJpZGdlO1xyXG51c2luZyBNYXRjaGluZ0dhbWVGcmFtZXdvcmtzO1xyXG51c2luZyBOZXd0b25zb2Z0Lkpzb247XHJcbnVzaW5nIFN5c3RlbTtcclxuXHJcbm5hbWVzcGFjZSBNYXRjaGluZ0dhbWVCcmlkZ2Vcclxue1xyXG5cdHB1YmxpYyBjbGFzcyBBcHBcclxuXHR7XHJcblx0XHRwdWJsaWMgc3RhdGljIHZvaWQgTWFpbigpXHJcblx0XHR7XHJcblx0XHRcdC8vIFdyaXRlIGEgbWVzc2FnZSB0byB0aGUgQ29uc29sZVxyXG5cdFx0XHRDb25zb2xlLldyaXRlTGluZShcIldlbGNvbWUgdG8gQnJpZGdlLk5FVFwiKTtcclxuXHRcdFx0Q2FyZCBjYXJkID0gbmV3IENhcmQoMCwgXCJpbWFnZS5naWZcIik7XHJcblx0XHRcdENvbnNvbGUuV3JpdGVMaW5lKGNhcmQpO1xyXG5cdFx0XHQvLyBBZnRlciBidWlsZGluZyAoQ3RybCArIFNoaWZ0ICsgQikgdGhpcyBwcm9qZWN0LCBcclxuXHRcdFx0Ly8gYnJvd3NlIHRvIHRoZSAvYmluL0RlYnVnIG9yIC9iaW4vUmVsZWFzZSBmb2xkZXIuXHJcblxyXG5cdFx0XHQvLyBBIG5ldyBicmlkZ2UvIGZvbGRlciBoYXMgYmVlbiBjcmVhdGVkIGFuZFxyXG5cdFx0XHQvLyBjb250YWlucyB5b3VyIHByb2plY3RzIEphdmFTY3JpcHQgZmlsZXMuIFxyXG5cclxuXHRcdFx0Ly8gT3BlbiB0aGUgYnJpZGdlL2luZGV4Lmh0bWwgZmlsZSBpbiBhIGJyb3dzZXIgYnlcclxuXHRcdFx0Ly8gUmlnaHQtQ2xpY2sgPiBPcGVuIFdpdGguLi4sIHRoZW4gY2hvb3NlIGFcclxuXHRcdFx0Ly8gd2ViIGJyb3dzZXIgZnJvbSB0aGUgbGlzdFxyXG5cclxuXHRcdFx0Ly8gVGhpcyBhcHBsaWNhdGlvbiB3aWxsIHRoZW4gcnVuIGluIHRoZSBicm93c2VyLlxyXG5cdFx0fVxyXG5cdH1cclxufVxyXG5uYW1lc3BhY2UgTWF0Y2hpbmdHYW1lRnJhbWV3b3Jrc1xyXG57XHJcblx0cHVibGljIGNsYXNzIENhcmRcclxuXHR7XHJcblx0XHRwcml2YXRlIGludCBpZDtcclxuXHJcblx0XHQvLy8gPHN1bW1hcnk+XHJcblx0XHQvLy8gSURcclxuXHRcdC8vLyA8L3N1bW1hcnk+XHJcblx0XHRwdWJsaWMgaW50IElEXHJcblx0XHR7XHJcblx0XHRcdGdldCB7IHJldHVybiBpZDsgfVxyXG5cdFx0XHRzZXQgeyBpZCA9IHZhbHVlOyB9XHJcblx0XHR9XHJcblx0XHRwcml2YXRlIHN0cmluZyBpbWFnZUxvY2F0aW9uO1xyXG5cclxuXHRcdC8vLyA8c3VtbWFyeT5cclxuXHRcdC8vLyBJbWFnZSBMb2NhdGlvblxyXG5cdFx0Ly8vIDwvc3VtbWFyeT5cclxuXHRcdHB1YmxpYyBzdHJpbmcgSW1hZ2VMb2NhdGlvblxyXG5cdFx0e1xyXG5cdFx0XHRnZXQgeyByZXR1cm4gaW1hZ2VMb2NhdGlvbjsgfVxyXG5cdFx0XHRzZXQgeyBpbWFnZUxvY2F0aW9uID0gdmFsdWU7IH1cclxuXHRcdH1cclxuXHRcdHByaXZhdGUgYm9vbCBmbGlwcGVkO1xyXG5cclxuXHRcdC8vLyA8c3VtbWFyeT5cclxuXHRcdC8vLyBjYXJkIGlzIGZsaXBlZCBvciBub3RcclxuXHRcdC8vLyA8L3N1bW1hcnk+XHJcblx0XHRwdWJsaWMgYm9vbCBGbGlwcGVkXHJcblx0XHR7XHJcblx0XHRcdGdldFxyXG5cdFx0XHR7XHJcblx0XHRcdFx0aWYgKHJlbW92ZWQpXHJcblx0XHRcdFx0e1xyXG5cdFx0XHRcdFx0cmV0dXJuIGZhbHNlO1xyXG5cdFx0XHRcdH1cclxuXHRcdFx0XHRyZXR1cm4gZmxpcHBlZDtcclxuXHRcdFx0fVxyXG5cdFx0XHRzZXQgeyBmbGlwcGVkID0gdmFsdWU7IH1cclxuXHRcdH1cclxuXHJcblx0XHRwcml2YXRlIGJvb2wgcmVtb3ZlZDtcclxuXHJcblx0XHQvLy8gPHN1bW1hcnk+XHJcblx0XHQvLy8gY2FyZCBpcyByZW1vdmVkXHJcblx0XHQvLy8gPC9zdW1tYXJ5PlxyXG5cdFx0cHVibGljIGJvb2wgUmVtb3ZlZFxyXG5cdFx0e1xyXG5cdFx0XHRnZXRcclxuXHRcdFx0e1xyXG5cdFx0XHRcdGlmIChpbWFnZUxvY2F0aW9uID09IFwiTi9BXCIpXHJcblx0XHRcdFx0e1xyXG5cdFx0XHRcdFx0cmV0dXJuIHRydWU7XHJcblx0XHRcdFx0fVxyXG5cdFx0XHRcdHJldHVybiByZW1vdmVkO1xyXG5cdFx0XHR9XHJcblx0XHRcdHNldCB7IHJlbW92ZWQgPSB2YWx1ZTsgfVxyXG5cdFx0fVxyXG5cclxuXHRcdHB1YmxpYyBDYXJkKClcclxuXHRcdHtcclxuXHRcdFx0ZmxpcHBlZCA9IGZhbHNlO1xyXG5cdFx0XHRyZW1vdmVkID0gZmFsc2U7XHJcblx0XHR9XHJcblxyXG5cdFx0cHVibGljIENhcmQoaW50IGlkLCBzdHJpbmcgaW1hZ2VMb2NhdGlvbilcclxuXHRcdHtcclxuXHRcdFx0dGhpcy5pZCA9IGlkO1xyXG5cdFx0XHR0aGlzLmltYWdlTG9jYXRpb24gPSBpbWFnZUxvY2F0aW9uO1xyXG5cdFx0XHRmbGlwcGVkID0gZmFsc2U7XHJcblx0XHRcdHJlbW92ZWQgPSBmYWxzZTtcclxuXHRcdH1cclxuXHJcblx0XHRwdWJsaWMgYm9vbCBJc01hdGNoKENhcmQgb3RoZXJDYXJkLCBib29sIHRocm93Q29tcGFyZVRvU2VsZkV4Y2VwdGlvbiA9IHRydWUpXHJcblx0XHR7XHJcblx0XHRcdGlmIChvdGhlckNhcmQgPT0gdGhpcylcclxuXHRcdFx0e1xyXG5cdFx0XHRcdHJldHVybiBmYWxzZTtcclxuXHRcdFx0fVxyXG5cclxuXHRcdFx0aWYgKHRoaXMuSUQgPT0gb3RoZXJDYXJkLklEKVxyXG5cdFx0XHR7XHJcblx0XHRcdFx0cmV0dXJuIHRydWU7XHJcblx0XHRcdH1cclxuXHRcdFx0ZWxzZVxyXG5cdFx0XHR7XHJcblx0XHRcdFx0cmV0dXJuIGZhbHNlO1xyXG5cdFx0XHR9XHJcblx0XHR9XHJcblxyXG5cdFx0cHVibGljIHZvaWQgRmxpcCgpXHJcblx0XHR7XHJcblx0XHRcdGZsaXBwZWQgPSAhZmxpcHBlZDtcclxuXHRcdH1cclxuXHJcblx0XHRwdWJsaWMgdm9pZCBSZW1vdmUoKVxyXG5cdFx0e1xyXG5cdFx0XHRyZW1vdmVkID0gdHJ1ZTtcclxuXHRcdH1cclxuXHJcblx0XHRwdWJsaWMgdm9pZCBSZXNldCgpXHJcblx0XHR7XHJcblx0XHRcdGZsaXBwZWQgPSBmYWxzZTtcclxuXHRcdFx0cmVtb3ZlZCA9IGZhbHNlO1xyXG5cdFx0fVxyXG5cdH1cclxuXHRwdWJsaWMgY2xhc3MgR2FtZVxyXG5cdHtcclxuXHRcdHByaXZhdGUgY29uc3QgaW50IE1JTklNVU1fQ0FSRF9JTl9BX1JPVyA9IDI7XHJcblxyXG5cdFx0cHJpdmF0ZSBDYXJkWyxdIGNhcmRzO1xyXG5cclxuXHRcdHB1YmxpYyBDYXJkWyxdIENhcmRzXHJcblx0XHR7XHJcblx0XHRcdGdldCB7IHJldHVybiAoQ2FyZFssXSljYXJkcy5DbG9uZSgpOyB9XHJcblx0XHR9XHJcblxyXG5cdFx0cHJpdmF0ZSBQb3NpdGlvbjJEIGNhcmRTaXplO1xyXG5cclxuXHRcdHB1YmxpYyBQb3NpdGlvbjJEIENhcmRTaXplXHJcblx0XHR7XHJcblx0XHRcdGdldCB7IHJldHVybiBuZXcgUG9zaXRpb24yRChjYXJkU2l6ZSk7IH1cclxuXHRcdFx0c2V0XHJcblx0XHRcdHtcclxuXHRcdFx0XHRjYXJkU2l6ZSA9IG5ldyBQb3NpdGlvbjJEKHZhbHVlKTtcclxuXHJcblx0XHRcdFx0aWYgKGNhcmRTaXplLlggPCBNSU5JTVVNX0NBUkRfSU5fQV9ST1cpXHJcblx0XHRcdFx0e1xyXG5cdFx0XHRcdFx0dGhyb3cgbmV3IEV4Y2VwdGlvbihcIkJlbG93IG1pbmltdW0gc2l6ZVwiKTtcclxuXHRcdFx0XHR9XHJcblxyXG5cdFx0XHRcdGlmIChjYXJkU2l6ZS5ZIDwgTUlOSU1VTV9DQVJEX0lOX0FfUk9XKVxyXG5cdFx0XHRcdHtcclxuXHRcdFx0XHRcdHRocm93IG5ldyBFeGNlcHRpb24oXCJCZWxvdyBtaW5pbXVtIHNpemVcIik7XHJcblx0XHRcdFx0fVxyXG5cclxuXHRcdFx0XHRpZiAoVG90YWxDYXJkQ291bnQgJSAyID09IDEpXHJcblx0XHRcdFx0e1xyXG5cdFx0XHRcdFx0dGhyb3cgbmV3IEV4Y2VwdGlvbihcIk9kZCBudW1iZXIgb2YgY2FyZHNcIik7XHJcblx0XHRcdFx0fVxyXG5cclxuXHRcdFx0XHRjYXJkcyA9IG5ldyBDYXJkW2NhcmRTaXplLlgsIGNhcmRTaXplLlldO1xyXG5cdFx0XHRcdGZvciAoaW50IHggPSAwOyB4IDwgY2FyZFNpemUuWDsgeCsrKVxyXG5cdFx0XHRcdHtcclxuXHRcdFx0XHRcdGZvciAoaW50IHkgPSAwOyB5IDwgY2FyZFNpemUuWTsgeSsrKVxyXG5cdFx0XHRcdFx0e1xyXG5cdFx0XHRcdFx0XHRjYXJkc1t4LCB5XSA9IG5ldyBDYXJkKCk7XHJcblx0XHRcdFx0XHRcdGNhcmRzW3gsIHldLklEID0geCArICh5ICogY2FyZFNpemUuWCk7XHJcblx0XHRcdFx0XHRcdGlmIChjYXJkc1t4LCB5XS5JRCA+PSBVbmlxdWVDYXJkQ291bnQpXHJcblx0XHRcdFx0XHRcdHtcclxuXHRcdFx0XHRcdFx0XHRjYXJkc1t4LCB5XS5JRCAtPSBVbmlxdWVDYXJkQ291bnQ7XHJcblx0XHRcdFx0XHRcdH1cclxuXHRcdFx0XHRcdH1cclxuXHRcdFx0XHR9XHJcblx0XHRcdH1cclxuXHRcdH1cclxuXHJcblx0XHQvL3ByaXZhdGUgTWF0Y2hpbmdHYW1lUGxheWVyU2NvcmUgcGxheWVyO1xyXG5cclxuXHRcdC8vcHVibGljIE1hdGNoaW5nR2FtZVBsYXllclNjb3JlIFBsYXllclxyXG5cdFx0Ly97XHJcblx0XHQvL1x0Z2V0IHsgcmV0dXJuIHBsYXllcjsgfVxyXG5cdFx0Ly9cdHNldCB7IHBsYXllciA9IHZhbHVlOyB9XHJcblx0XHQvL31cclxuXHJcblxyXG5cdFx0cHJpdmF0ZSBzdHJpbmcgYmFja09mQ2FyZEltYWdlTG9jYXRpb247XHJcblxyXG5cdFx0cHVibGljIHN0cmluZyBCYWNrT2ZDYXJkSW1hZ2VMb2NhdGlvblxyXG5cdFx0e1xyXG5cdFx0XHRnZXQgeyByZXR1cm4gYmFja09mQ2FyZEltYWdlTG9jYXRpb247IH1cclxuXHRcdFx0c2V0IHsgYmFja09mQ2FyZEltYWdlTG9jYXRpb24gPSB2YWx1ZTsgfVxyXG5cdFx0fVxyXG5cclxuXHRcdHB1YmxpYyBHYW1lKGludCBjb2x1bW5zQ291bnQsIGludCByb3dDb3VudClcclxuXHRcdHtcclxuXHRcdFx0Q2FyZFNpemUgPSBuZXcgUG9zaXRpb24yRChjb2x1bW5zQ291bnQsIHJvd0NvdW50KTtcclxuXHRcdH1cclxuXHJcblx0XHRwdWJsaWMgaW50IFRvdGFsQ2FyZENvdW50XHJcblx0XHR7XHJcblx0XHRcdGdldFxyXG5cdFx0XHR7XHJcblx0XHRcdFx0cmV0dXJuIGNhcmRTaXplLkFyZWE7XHJcblx0XHRcdH1cclxuXHRcdH1cclxuXHJcblx0XHRwdWJsaWMgaW50IFVuaXF1ZUNhcmRDb3VudFxyXG5cdFx0e1xyXG5cdFx0XHRnZXRcclxuXHRcdFx0e1xyXG5cdFx0XHRcdHJldHVybiBjYXJkU2l6ZS5BcmVhIC8gMjtcclxuXHRcdFx0fVxyXG5cdFx0fVxyXG5cclxuXHJcblx0XHRwdWJsaWMgdm9pZCBSZXNldEdhbWUoKVxyXG5cdFx0e1xyXG5cdFx0XHRmb3IgKGludCB4ID0gMDsgeCA8IGNhcmRTaXplLlg7IHgrKylcclxuXHRcdFx0e1xyXG5cdFx0XHRcdGZvciAoaW50IHkgPSAwOyB5IDwgY2FyZFNpemUuWTsgeSsrKVxyXG5cdFx0XHRcdHtcclxuXHRcdFx0XHRcdGNhcmRzW3gsIHldLlJlc2V0KCk7XHJcblx0XHRcdFx0fVxyXG5cdFx0XHR9XHJcblx0XHR9XHJcblxyXG5cdFx0cHVibGljIHZvaWQgU3dpdGNoU3BvdHMocmVmIENhcmQgY2FyZDEsIHJlZiBDYXJkIGNhcmQyLCBib29sIHRocm93Q29tcGFyZVRvU2VsZkV4Y2VwdGlvbiA9IHRydWUpXHJcblx0XHR7XHJcblx0XHRcdGlmIChjYXJkMSAhPSBjYXJkMilcclxuXHRcdFx0e1xyXG5cdFx0XHRcdENhcmQgdGVtcCA9IGNhcmQxO1xyXG5cdFx0XHRcdGNhcmQxID0gY2FyZDI7XHJcblx0XHRcdFx0Y2FyZDIgPSB0ZW1wO1xyXG5cdFx0XHR9XHJcblx0XHR9XHJcblxyXG5cdFx0cHVibGljIHZvaWQgU2h1ZmZsZShpbnQgbnVtYmVyT2ZTaHVmZmxlcyA9IDEpXHJcblx0XHR7XHJcblx0XHRcdGlmIChudW1iZXJPZlNodWZmbGVzIDwgMSlcclxuXHRcdFx0e1xyXG5cdFx0XHRcdHRocm93IG5ldyBFeGNlcHRpb24oXCJCZWxvdyBNaW5pbXVtXCIpO1xyXG5cdFx0XHR9XHJcblxyXG5cdFx0XHRSYW5kb20gcmFuZG9tID0gbmV3IFJhbmRvbSgpO1xyXG5cdFx0XHRmb3IgKGludCB6ID0gMDsgeiA8IG51bWJlck9mU2h1ZmZsZXM7IHorKylcclxuXHRcdFx0e1xyXG5cdFx0XHRcdGZvciAoaW50IHggPSAwOyB4IDwgY2FyZFNpemUuWDsgeCsrKVxyXG5cdFx0XHRcdHtcclxuXHRcdFx0XHRcdGZvciAoaW50IHkgPSAwOyB5IDwgY2FyZFNpemUuWTsgeSsrKVxyXG5cdFx0XHRcdFx0e1xyXG5cdFx0XHRcdFx0XHRpbnQgWCA9IHJhbmRvbS5OZXh0KGNhcmRTaXplLlgpO1xyXG5cdFx0XHRcdFx0XHRpbnQgWSA9IHJhbmRvbS5OZXh0KGNhcmRTaXplLlkpO1xyXG5cdFx0XHRcdFx0XHRTd2l0Y2hTcG90cyhyZWYgY2FyZHNbeCwgeV0sIHJlZiBjYXJkc1tYLCBZXSwgZmFsc2UpO1xyXG5cdFx0XHRcdFx0fVxyXG5cdFx0XHRcdH1cclxuXHRcdFx0fVxyXG5cdFx0fVxyXG5cclxuXHRcdC8vcHVibGljIHZvaWQgU2V0SW1hZ2Uoc3RyaW5nIHBhdGgsIEltYWdlTmFtZURhdGFiYXNlIGltYWdlTmFtZURhdGFiYXNlKVxyXG5cdFx0Ly97XHJcblx0XHQvL1x0Zm9yIChpbnQgeCA9IDA7IHggPCBjYXJkU2l6ZS5YOyB4KyspXHJcblx0XHQvL1x0e1xyXG5cdFx0Ly9cdFx0Zm9yIChpbnQgeSA9IDA7IHkgPCBjYXJkU2l6ZS5ZOyB5KyspXHJcblx0XHQvL1x0XHR7XHJcblx0XHQvL1x0XHRcdGlmIChjYXJkc1t4LCB5XS5JRCA+PSBpbWFnZU5hbWVEYXRhYmFzZS5JbWFnZU5hbWUuTGVuZ3RoKVxyXG5cdFx0Ly9cdFx0XHR7XHJcblx0XHQvL1x0XHRcdFx0Y2FyZHNbeCwgeV0uSW1hZ2VMb2NhdGlvbiA9IFwiTi9BXCI7XHJcblx0XHQvL1x0XHRcdH1cclxuXHRcdC8vXHRcdFx0ZWxzZVxyXG5cdFx0Ly9cdFx0XHR7XHJcblx0XHQvL1x0XHRcdFx0Y2FyZHNbeCwgeV0uSW1hZ2VMb2NhdGlvbiA9XHJcblx0XHQvL1x0XHRcdFx0XHRwYXRoICsgXCJcXFxcXCIgKyBpbWFnZU5hbWVEYXRhYmFzZS5JbWFnZU5hbWVbY2FyZHNbeCwgeV0uSURdO1xyXG5cdFx0Ly9cdFx0XHR9XHJcblx0XHQvL1x0XHR9XHJcblx0XHQvL1x0fVxyXG5cdFx0Ly99XHJcblxyXG5cdFx0cHVibGljIHN0cmluZyBHZXRJbWFnZShpbnQgY29sdW1uLCBpbnQgcm93KVxyXG5cdFx0e1xyXG5cdFx0XHRpZiAoY2FyZHNbY29sdW1uLCByb3ddLkZsaXBwZWQpXHJcblx0XHRcdHtcclxuXHRcdFx0XHRyZXR1cm4gY2FyZHNbY29sdW1uLCByb3ddLkltYWdlTG9jYXRpb247XHJcblx0XHRcdH1cclxuXHRcdFx0ZWxzZVxyXG5cdFx0XHR7XHJcblx0XHRcdFx0cmV0dXJuIGJhY2tPZkNhcmRJbWFnZUxvY2F0aW9uO1xyXG5cdFx0XHR9XHJcblx0XHR9XHJcblxyXG5cdFx0cHVibGljIHZvaWQgSGlkZUFsbENhcmRzKClcclxuXHRcdHtcclxuXHRcdFx0Zm9yIChpbnQgeCA9IDA7IHggPCBjYXJkU2l6ZS5YOyB4KyspXHJcblx0XHRcdHtcclxuXHRcdFx0XHRmb3IgKGludCB5ID0gMDsgeSA8IGNhcmRTaXplLlk7IHkrKylcclxuXHRcdFx0XHR7XHJcblx0XHRcdFx0XHRjYXJkc1t4LCB5XS5GbGlwcGVkID0gZmFsc2U7XHJcblx0XHRcdFx0fVxyXG5cdFx0XHR9XHJcblx0XHR9XHJcblxyXG5cdFx0cHVibGljIGludCBGbGlwZWRDYXJkc0NvdW50XHJcblx0XHR7XHJcblx0XHRcdGdldFxyXG5cdFx0XHR7XHJcblx0XHRcdFx0aW50IGZsaXBDYXJkc0NvdW50ID0gMDtcclxuXHRcdFx0XHRmb3IgKGludCB4ID0gMDsgeCA8IGNhcmRTaXplLlg7IHgrKylcclxuXHRcdFx0XHR7XHJcblx0XHRcdFx0XHRmb3IgKGludCB5ID0gMDsgeSA8IGNhcmRTaXplLlk7IHkrKylcclxuXHRcdFx0XHRcdHtcclxuXHRcdFx0XHRcdFx0aWYgKGNhcmRzW3gsIHldLkZsaXBwZWQpXHJcblx0XHRcdFx0XHRcdHtcclxuXHRcdFx0XHRcdFx0XHRmbGlwQ2FyZHNDb3VudCsrO1xyXG5cdFx0XHRcdFx0XHR9XHJcblx0XHRcdFx0XHR9XHJcblx0XHRcdFx0fVxyXG5cdFx0XHRcdHJldHVybiBmbGlwQ2FyZHNDb3VudDtcclxuXHRcdFx0fVxyXG5cdFx0fVxyXG5cclxuXHRcdGludCB0ZXN0O1xyXG5cclxuXHRcdHB1YmxpYyBpbnQgVGVzdFxyXG5cdFx0e1xyXG5cdFx0XHRnZXQgeyByZXR1cm4gdGVzdDsgfVxyXG5cdFx0XHRzZXQgeyB0ZXN0ID0gdmFsdWU7IH1cclxuXHRcdH1cclxuXHJcblxyXG5cdFx0cHVibGljIGludCBSZW1vdmVkQ2FyZHNDb3VudFxyXG5cdFx0e1xyXG5cdFx0XHRnZXRcclxuXHRcdFx0e1xyXG5cdFx0XHRcdGludCByZW1vdmVkQ2FyZHNDb3VudCA9IDA7XHJcblx0XHRcdFx0Zm9yIChpbnQgeCA9IDA7IHggPCBjYXJkU2l6ZS5YOyB4KyspXHJcblx0XHRcdFx0e1xyXG5cdFx0XHRcdFx0Zm9yIChpbnQgeSA9IDA7IHkgPCBjYXJkU2l6ZS5ZOyB5KyspXHJcblx0XHRcdFx0XHR7XHJcblx0XHRcdFx0XHRcdGlmIChjYXJkc1t4LCB5XS5SZW1vdmVkKVxyXG5cdFx0XHRcdFx0XHR7XHJcblx0XHRcdFx0XHRcdFx0cmVtb3ZlZENhcmRzQ291bnQrKztcclxuXHRcdFx0XHRcdFx0fVxyXG5cdFx0XHRcdFx0fVxyXG5cdFx0XHRcdH1cclxuXHRcdFx0XHRyZXR1cm4gcmVtb3ZlZENhcmRzQ291bnQ7XHJcblx0XHRcdH1cclxuXHRcdH1cclxuXHJcblx0XHRwdWJsaWMgYm9vbCBGbGlwZWRDYXJkc01hdGNoXHJcblx0XHR7XHJcblx0XHRcdGdldFxyXG5cdFx0XHR7XHJcblx0XHRcdFx0aWYgKEZsaXBlZENhcmRzQ291bnQgIT0gMilcclxuXHRcdFx0XHR7XHJcblx0XHRcdFx0XHRyZXR1cm4gZmFsc2U7XHJcblx0XHRcdFx0fVxyXG5cdFx0XHRcdENhcmQgY2FyZDEgPSBudWxsO1xyXG5cdFx0XHRcdENhcmQgY2FyZDIgPSBudWxsO1xyXG5cdFx0XHRcdGZvciAoaW50IHggPSAwOyB4IDwgY2FyZFNpemUuWDsgeCsrKVxyXG5cdFx0XHRcdHtcclxuXHRcdFx0XHRcdGZvciAoaW50IHkgPSAwOyB5IDwgY2FyZFNpemUuWTsgeSsrKVxyXG5cdFx0XHRcdFx0e1xyXG5cdFx0XHRcdFx0XHRpZiAoY2FyZHNbeCwgeV0uRmxpcHBlZClcclxuXHRcdFx0XHRcdFx0e1xyXG5cdFx0XHRcdFx0XHRcdGlmIChjYXJkMSA9PSBudWxsKVxyXG5cdFx0XHRcdFx0XHRcdHtcclxuXHRcdFx0XHRcdFx0XHRcdGNhcmQxID0gY2FyZHNbeCwgeV07XHJcblx0XHRcdFx0XHRcdFx0fVxyXG5cdFx0XHRcdFx0XHRcdGVsc2VcclxuXHRcdFx0XHRcdFx0XHR7XHJcblx0XHRcdFx0XHRcdFx0XHRjYXJkMiA9IGNhcmRzW3gsIHldO1xyXG5cdFx0XHRcdFx0XHRcdH1cclxuXHRcdFx0XHRcdFx0fVxyXG5cdFx0XHRcdFx0fS8vbmV4dCB5XHJcblx0XHRcdFx0fS8vbmV4dCB4XHJcblx0XHRcdFx0cmV0dXJuIGNhcmQxLklzTWF0Y2goY2FyZDIpO1xyXG5cdFx0XHR9XHJcblxyXG5cdFx0fVxyXG5cclxuXHRcdHB1YmxpYyB2b2lkIFJlbW92ZUZsaXBlZENhcmRzKClcclxuXHRcdHtcclxuXHRcdFx0Zm9yIChpbnQgeCA9IDA7IHggPCBjYXJkU2l6ZS5YOyB4KyspXHJcblx0XHRcdHtcclxuXHRcdFx0XHRmb3IgKGludCB5ID0gMDsgeSA8IGNhcmRTaXplLlk7IHkrKylcclxuXHRcdFx0XHR7XHJcblx0XHRcdFx0XHRpZiAoY2FyZHNbeCwgeV0uRmxpcHBlZClcclxuXHRcdFx0XHRcdHtcclxuXHRcdFx0XHRcdFx0Y2FyZHNbeCwgeV0uUmVtb3ZlZCA9IHRydWU7IDtcclxuXHRcdFx0XHRcdH1cclxuXHRcdFx0XHR9Ly9uZXh0IHlcclxuXHRcdFx0fS8vbmV4dCB4XHJcblx0XHR9XHJcblxyXG5cdFx0cHVibGljIGJvb2wgR2FtZUNvbXBsZXRlXHJcblx0XHR7XHJcblx0XHRcdGdldFxyXG5cdFx0XHR7XHJcblx0XHRcdFx0cmV0dXJuIEhpZGRlbkNhcmRDb3VudCA9PSAwO1xyXG5cdFx0XHR9XHJcblx0XHR9XHJcblxyXG5cdFx0cHVibGljIGludCBDYXJkc1JlbWFpblxyXG5cdFx0e1xyXG5cdFx0XHRnZXRcclxuXHRcdFx0e1xyXG5cdFx0XHRcdGludCBjYXJkc1JlbWFpbiA9IDA7XHJcblx0XHRcdFx0Zm9yIChpbnQgeCA9IDA7IHggPCBjYXJkU2l6ZS5YOyB4KyspXHJcblx0XHRcdFx0e1xyXG5cdFx0XHRcdFx0Zm9yIChpbnQgeSA9IDA7IHkgPCBjYXJkU2l6ZS5ZOyB5KyspXHJcblx0XHRcdFx0XHR7XHJcblx0XHRcdFx0XHRcdGlmICghY2FyZHNbeCwgeV0uUmVtb3ZlZClcclxuXHRcdFx0XHRcdFx0e1xyXG5cdFx0XHRcdFx0XHRcdGNhcmRzUmVtYWluKys7XHJcblx0XHRcdFx0XHRcdH1cclxuXHRcdFx0XHRcdH1cclxuXHRcdFx0XHR9XHJcblxyXG5cdFx0XHRcdHJldHVybiBjYXJkc1JlbWFpbjtcclxuXHRcdFx0fVxyXG5cdFx0fVxyXG5cclxuXHRcdHB1YmxpYyBpbnQgSGlkZGVuQ2FyZENvdW50XHJcblx0XHR7XHJcblx0XHRcdGdldFxyXG5cdFx0XHR7XHJcblx0XHRcdFx0aW50IGhpZGRlbkNhcmRzQ291bnQgPSAwO1xyXG5cdFx0XHRcdGZvciAoaW50IHggPSAwOyB4IDwgY2FyZFNpemUuWDsgeCsrKVxyXG5cdFx0XHRcdHtcclxuXHRcdFx0XHRcdGZvciAoaW50IHkgPSAwOyB5IDwgY2FyZFNpemUuWTsgeSsrKVxyXG5cdFx0XHRcdFx0e1xyXG5cdFx0XHRcdFx0XHRpZiAoIShjYXJkc1t4LCB5XS5GbGlwcGVkIHx8IGNhcmRzW3gsIHldLlJlbW92ZWQpKVxyXG5cdFx0XHRcdFx0XHR7XHJcblx0XHRcdFx0XHRcdFx0aGlkZGVuQ2FyZHNDb3VudCsrO1xyXG5cdFx0XHRcdFx0XHR9XHJcblx0XHRcdFx0XHR9XHJcblx0XHRcdFx0fVxyXG5cdFx0XHRcdHJldHVybiBoaWRkZW5DYXJkc0NvdW50O1xyXG5cdFx0XHR9XHJcblx0XHR9XHJcblxyXG5cdH1cclxufVxyXG5uYW1lc3BhY2UgQkNfRnVuY3Rpb25zXHJcbntcclxuXHRwdWJsaWMgY2xhc3MgUG9zaXRpb24yRFxyXG5cdHtcclxuXHRcdHByaXZhdGUgaW50IHg7XHJcblxyXG5cdFx0cHVibGljIGludCBYXHJcblx0XHR7XHJcblx0XHRcdGdldCB7IHJldHVybiB4OyB9XHJcblx0XHRcdHNldCB7IHggPSB2YWx1ZTsgfVxyXG5cdFx0fVxyXG5cdFx0cHJpdmF0ZSBpbnQgeTtcclxuXHJcblx0XHRwdWJsaWMgaW50IFlcclxuXHRcdHtcclxuXHRcdFx0Z2V0IHsgcmV0dXJuIHk7IH1cclxuXHRcdFx0c2V0IHsgeSA9IHZhbHVlOyB9XHJcblx0XHR9XHJcblxyXG5cdFx0cHVibGljIFBvc2l0aW9uMkQoKVxyXG5cdFx0e1xyXG5cdFx0XHR4ID0gMDtcclxuXHRcdFx0eCA9IDA7XHJcblx0XHR9XHJcblxyXG5cdFx0cHVibGljIFBvc2l0aW9uMkRcclxuXHRcdFx0KGludCBwb3NpdGlvbilcclxuXHRcdHtcclxuXHRcdFx0eCA9IHBvc2l0aW9uO1xyXG5cdFx0XHR5ID0gcG9zaXRpb247XHJcblx0XHR9XHJcblx0XHRwdWJsaWMgUG9zaXRpb24yRFxyXG5cdFx0XHQoaW50IHgsXHJcblx0XHRcdGludCB5KVxyXG5cdFx0e1xyXG5cdFx0XHR0aGlzLnggPSB4O1xyXG5cdFx0XHR0aGlzLnkgPSB5O1xyXG5cdFx0fVxyXG5cdFx0cHVibGljIFBvc2l0aW9uMkQoUG9zaXRpb24yRCBwb3NpdGlvbilcclxuXHRcdHtcclxuXHRcdFx0dGhpcy54ID0gcG9zaXRpb24ueDtcclxuXHRcdFx0dGhpcy55ID0gcG9zaXRpb24ueTtcclxuXHRcdH1cclxuXHJcblx0XHRwdWJsaWMgdmlydHVhbCB2b2lkIFNldFBvc2l0aW9uKGludCB4LCBpbnQgeSlcclxuXHRcdHtcclxuXHRcdFx0dGhpcy54ID0geDtcclxuXHRcdFx0dGhpcy55ID0geTtcclxuXHRcdH1cclxuXHJcblx0XHRwdWJsaWMgb3ZlcnJpZGUgc3RyaW5nIFRvU3RyaW5nKClcclxuXHRcdHtcclxuXHRcdFx0cmV0dXJuIFwiKFwiICsgWC5Ub1N0cmluZygpICsgXCIsXCIgKyBZLlRvU3RyaW5nKCkgKyBcIilcIjtcclxuXHRcdH1cclxuXHJcblx0XHRwdWJsaWMgdmlydHVhbCB2b2lkIFNldFBvc2l0aW9uKGludCBwb3NpdGlvbilcclxuXHRcdHtcclxuXHRcdFx0eCA9IHBvc2l0aW9uO1xyXG5cdFx0XHR5ID0gcG9zaXRpb247XHJcblx0XHR9XHJcblxyXG5cdFx0cHVibGljIHZpcnR1YWwgdm9pZCBTZXRQb3NpdGlvbihQb3NpdGlvbjJEIHBvc2l0aW9uKVxyXG5cdFx0e1xyXG5cdFx0XHRTZXRQb3NpdGlvbihwb3NpdGlvbi5YLCBwb3NpdGlvbi5ZKTtcclxuXHRcdH1cclxuXHJcblx0XHRwdWJsaWMgdmlydHVhbCBpbnQgQXJlYVxyXG5cdFx0e1xyXG5cdFx0XHRnZXRcclxuXHRcdFx0e1xyXG5cdFx0XHRcdHJldHVybiB4ICogeTtcclxuXHRcdFx0fVxyXG5cdFx0fVxyXG5cclxuXHRcdHB1YmxpYyBzdGF0aWMgUG9zaXRpb24yRCBvcGVyYXRvciArKFBvc2l0aW9uMkQgYSwgUG9zaXRpb24yRCBiKVxyXG5cdFx0e1xyXG5cdFx0XHRyZXR1cm4gbmV3IFBvc2l0aW9uMkQoYS54ICsgYi54LCBhLnkgKyBiLnkpO1xyXG5cdFx0fVxyXG5cclxuXHRcdHB1YmxpYyBzdGF0aWMgUG9zaXRpb24yRCBvcGVyYXRvciAtKFBvc2l0aW9uMkQgYSwgUG9zaXRpb24yRCBiKVxyXG5cdFx0e1xyXG5cdFx0XHRyZXR1cm4gbmV3IFBvc2l0aW9uMkQoYS54IC0gYi54LCBhLnkgLSBiLnkpO1xyXG5cdFx0fVxyXG5cclxuXHRcdHB1YmxpYyBzdGF0aWMgUG9zaXRpb24yRCBvcGVyYXRvciAqKFBvc2l0aW9uMkQgcG9zLCBpbnQgdmFsdWUpXHJcblx0XHR7XHJcblx0XHRcdHJldHVybiBuZXcgUG9zaXRpb24yRChwb3MueCAqIHZhbHVlLCBwb3MueSAqIHZhbHVlKTtcclxuXHRcdH1cclxuXHJcblx0fVxyXG59Il0KfQo=
